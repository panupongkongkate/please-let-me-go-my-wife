// Mermaid module for Blazor Server (adapted from WebAssembly approach)

// For Blazor Server, we can't use ES6 imports, so we assume mermaid is loaded globally
export function Initialize() {
    if (typeof mermaid !== 'undefined') {
        mermaid.initialize({ 
            startOnLoad: false, 
            theme: 'default',
            securityLevel: 'loose',
            flowchart: { useMaxWidth: true }
        });
        console.log('Mermaid initialized via module');
        return true;
    } else {
        console.error('Mermaid library not available');
        return false;
    }
}

export function Render(componentId) {
    if (typeof mermaid === 'undefined') {
        console.error('Mermaid not available for rendering');
        return false;
    }

    try {
        // Find all mermaid elements (including in hidden tabs)
        const elements = document.querySelectorAll(`.${componentId}, pre.${componentId}`);
        console.log(`Found ${elements.length} elements with class: ${componentId}`);
        
        let renderCount = 0;
        let processedCount = 0;
        
        for (const element of elements) {
            // Check if element is visible or in current tab
            const isVisible = element.offsetParent !== null || 
                             element.style.display !== 'none' || 
                             getComputedStyle(element).visibility !== 'hidden';
            
            // Check element content and state
            const textContent = element.textContent ? element.textContent.trim() : '';
            const hasTextContent = textContent.length > 0;
            const isAlreadySvg = element.querySelector('svg') !== null;
            const isProcessed = element.getAttribute('data-processed');
            
            console.log(`Element check - Visible: ${isVisible}, HasText: ${hasTextContent}, HasSVG: ${isAlreadySvg}, Processed: ${isProcessed}`);
            console.log(`Text content preview: ${textContent.substring(0, 50)}...`);
            
            if (hasTextContent && !isAlreadySvg && !isProcessed && (textContent.includes('Diagram') || textContent.includes('flowchart') || textContent.includes('erDiagram') || textContent.includes('stateDiagram'))) {
                const diagramDefinition = htmlDecode(element.innerHTML).trim();
                console.log(`Processing diagram: ${diagramDefinition.substring(0, 100)}...`);
                
                const id = "mmd" + Math.round(Math.random() * 10000);
                element.setAttribute('data-processed', 'true');
                
                mermaid.render(`${id}-svg`, diagramDefinition).then(result => {
                    element.innerHTML = result.svg;
                    console.log(`Successfully rendered diagram: ${id}`);
                }).catch(error => {
                    console.error(`Render error for ${id}:`, error);
                    element.innerHTML = `<div style="color: red; padding: 10px; border: 1px solid red;">Mermaid Error: ${error.message}</div>`;
                });
                
                renderCount++;
            } else if (isAlreadySvg) {
                processedCount++;
            }
        }
        
        console.log(`Render stats - New: ${renderCount}, Already processed: ${processedCount}`);
        return renderCount > 0 || processedCount > 0;
    } catch (error) {
        console.error('Mermaid rendering error:', error);
        return false;
    }
}

export function ResetProcessing(componentId) {
    try {
        const elements = document.getElementsByClassName(componentId);
        for (const element of elements) {
            element.removeAttribute('data-processed');
        }
        console.log(`Reset processing state for ${elements.length} elements`);
        return true;
    } catch (error) {
        console.error('Reset processing error:', error);
        return false;
    }
}

function htmlDecode(input) {
    const doc = new DOMParser().parseFromString(input, "text/html");
    return doc.documentElement.textContent;
}