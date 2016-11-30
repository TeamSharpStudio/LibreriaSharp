package libreriaSharp.ficheros;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import org.w3c.dom.Attr;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

/**
 * @author Sergio Lucena Fernández ( GitHub: https://github.com/SergioLucenaFdz )
 * @author Daniel Ramírez Sánchez ( GitHub: https://github.com/sirdan93 )
 * @team TeamSharp Studio ( GitHub: https://github.com/TeamSharpStudio )
 * @repository LibreriaSharp ( GitHub: https://github.com/TeamSharpStudio/LibreriaSharp )
 */

public class FicheroXML
{
    Element rootElement;
    String nombre, ruta;
    DocumentBuilderFactory docFactory;
    DocumentBuilder docBuilder;
    Document doc;
    
    public FicheroXML(String nombre, String ruta, String elementoRaiz) throws ParserConfigurationException
    {
        this.nombre = nombre;
        this.ruta = ruta;
        
        docFactory = DocumentBuilderFactory.newInstance();
	docBuilder = docFactory.newDocumentBuilder();
        doc = docBuilder.newDocument();
        rootElement = doc.createElement(elementoRaiz);
        doc.appendChild(rootElement);
    }
    
    public Element crearElemento(String etiqueta) throws FileNotFoundException, IOException
    {  
        Element elemento = doc.createElement(etiqueta);
        rootElement.appendChild(elemento);
        return elemento;
    }
    public void añadirAtributoAElemento(Element elemento, String atributo, String valor)
    {
        Attr attr = doc.createAttribute(atributo);
        attr.setValue(valor);
        elemento.setAttributeNode(attr);
    }
    
    public Element crearElementoHijo(Element elemento, String etiqueta){
        Element hijo = doc.createElement(etiqueta);
        elemento.appendChild(hijo);
        return hijo;
    }
    
    public Element crearElementoHijo(Element elemento, String etiqueta, String nodoTexto){
        Element hijo = doc.createElement(etiqueta);
        hijo.appendChild(doc.createTextNode(nodoTexto));
        elemento.appendChild(hijo);
        return hijo;
    }
    
    public void CrearArchivo() throws TransformerException, ParserConfigurationException
    {
        // Escribe todo el contenido final en un xml
        TransformerFactory transformerFactory = TransformerFactory.newInstance();
        Transformer transformer = transformerFactory.newTransformer();
        DOMSource source = new DOMSource(doc);
        StreamResult result = new StreamResult(new File(this.ruta+this.nombre+".xml"));

        // Descomentar para leer desde consola
        // StreamResult result = new StreamResult(System.out);

        transformer.transform(source, result);

        System.out.println("XML guardado!");
    }
}
