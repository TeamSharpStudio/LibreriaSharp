/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package libreriaSharp.ficheros;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;

/**
 * @author Sergio Lucena Fernández ( GitHub: https://github.com/SergioLucenaFdz )
 * @author Daniel Ramírez Sánchez ( GitHub: https://github.com/sirdan93 )
 * @team TeamSharp Studio ( GitHub: https://github.com/TeamSharpStudio )
 * @repository LibreriaSharp ( GitHub: https://github.com/TeamSharpStudio/LibreriaSharp )
 */

public abstract class Fichero
{
    String nombre, ruta;
    
    public Fichero(String nombre, String ruta)
    {
        this.nombre = nombre;
        this.ruta = ruta;
    }
    
    public abstract void crearFichero() throws FileNotFoundException, IOException;
    public abstract void empezarAEscribir() throws FileNotFoundException, IOException;
    public abstract void terminarDeEscribir() throws IOException;
    public abstract File devolverArchivoCompleto();
}