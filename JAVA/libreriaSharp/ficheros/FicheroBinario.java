/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package libreriaSharp.ficheros;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

/**
 * @author Sergio Lucena Fernández ( GitHub: https://github.com/SergioLucenaFdz )
 * @author Daniel Ramírez Sánchez ( GitHub: https://github.com/sirdan93 )
 * @team TeamSharp Studio ( GitHub: https://github.com/TeamSharpStudio )
 * @repository LibreriaSharp ( GitHub: https://github.com/TeamSharpStudio/LibreriaSharp )
 */

public class FicheroBinario extends Fichero
{
    File archivo;
    FileOutputStream fileOutputStream;
    DataOutputStream escritorDeDatos;
    
    public FicheroBinario(String nombre, String ruta)
    {
        super(nombre, ruta);
        archivo = new File(this.ruta+this.nombre+".dat");
    }
    
    @Override
    public void crearFichero() throws FileNotFoundException, IOException
    {
        fileOutputStream=new FileOutputStream(archivo);
        archivo.getParentFile().mkdirs();
        System.out.printf("El archivo creado está en %s\n", archivo.getAbsolutePath());
    }
    
    @Override
    public void empezarAEscribir() throws FileNotFoundException, IOException
    {
        escritorDeDatos = new DataOutputStream(fileOutputStream);
    }
    
    public void escribirUTF8(String linea) throws FileNotFoundException, IOException
    {  
        try
        {
            escritorDeDatos.writeUTF(linea);
        }
        catch(NullPointerException e)
        {
            System.err.println("\n\t\t\t\t\t\t-Solución: ANTES TIENES QUE ejecutar empezarAEscribir()- (no te olvides de llamar a terminarDeEscribir() despues)\n");
        }
    }
    
    public void escribirInt(int numero) throws FileNotFoundException, IOException
    {  
        try
        {
            escritorDeDatos.writeInt(numero);
        }
        catch(NullPointerException e)
        {
            System.err.println("\n\t\t\t\t\t\t-Solución: ANTES TIENES QUE ejecutar empezarAEscribirUTF8()- (no te olvides de llamar a terminarDeEscribir() despues)\n");
        }
    }
    
    public void escribirFloat(float numero) throws FileNotFoundException, IOException
    {  
        try
        {
            escritorDeDatos.writeFloat(numero);
        }
        catch(NullPointerException e)
        {
            System.err.println("\n\t\t\t\t\t\t-Solución: ANTES TIENES QUE ejecutar empezarAEscribirUTF8()- (no te olvides de llamar a terminarDeEscribir() despues)\n");
        }
    }
    
    public void reemplazarEnElFichero(String palabra, String reemplazo) throws IOException
    {
        Path path = Paths.get(this.ruta+this.nombre+".dat");
        Charset charset = StandardCharsets.UTF_8;

        String content = new String(Files.readAllBytes(path), charset);
        content = content.replaceAll(palabra.trim(), reemplazo.trim());
        Files.write(path, content.getBytes(charset));
    }
    
    @Override
    public void terminarDeEscribir() throws IOException
    {
        escritorDeDatos.close();
    }
    
    @Override
    public File devolverArchivoCompleto()
    {
        return this.archivo;
    }
    
    public void leerArchivoLineaALinea() throws FileNotFoundException, IOException
    {
        BufferedReader br = new BufferedReader(new FileReader(this.archivo));
        
	String line = null;
	while ((line = br.readLine()) != null) {
		System.out.println(line+"H");
	}
 
	br.close();
    }
}