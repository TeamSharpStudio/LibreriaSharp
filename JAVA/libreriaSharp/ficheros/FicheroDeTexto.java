package libreriaSharp.ficheros;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;

/**
 * @author Sergio Lucena Fernández ( GitHub: https://github.com/SergioLucenaFdz )
 * @author Daniel Ramírez Sánchez ( GitHub: https://github.com/sirdan93 )
 * @team TeamSharp Studio ( GitHub: https://github.com/TeamSharpStudio )
 * @repository LibreriaSharp ( GitHub: https://github.com/TeamSharpStudio/LibreriaSharp )
 */

public class FicheroDeTexto extends Fichero{
    File archivo;
    PrintWriter writer;
    
    public FicheroDeTexto(String nombre, String ruta)
    {
        super(nombre, ruta);
        archivo = new File(this.ruta+this.nombre+".txt");
    }
    
    public void crearFicheroContabilidad() throws FileNotFoundException, IOException
    {
        archivo.getParentFile().mkdirs();
        writer = new PrintWriter(archivo, "UTF-8");
        //<editor-fold desc="Todas las líneas del archivo original, para forzar el archivo en UTF-8 y evitar problemas">
        writer.println("02/01/2012 Nomina 1500.00 I");
        writer.println("02/01/2012 Nomina 500.00 G");
        writer.println("02/02/2012 Luz 50.00 G");
        writer.println("03/02/2012 Nomina 1300.00 I");
        writer.println("01/01/2013 otros 1.00 I");
        writer.println("01/01/2013 ADSL 35.00 G");
        writer.println("02/01/2013 Carburante 150.00 G");
        writer.println("03/01/2013 Gas 50.00 G");
        writer.println("04/01/2013 Gastos_varios 35.00 G");
        writer.println("02/01/2014 Gastos_varios 36.00 G");
        writer.println("04/01/2014 Intereses_cuentas 50.00 I");
        writer.println("05/01/2014 Alquileres 5.00 I");
        writer.println("25/02/2014 Otro_ingreso 5.00 I");
        writer.println("03/01/2015 Gastos_comunes 37.00 G");
        writer.println("04/01/2015 Luz 38.00 G");
        writer.println("05/01/2015 Gas 39.00 G");
        writer.println("06/01/2015 Agua 40.00 G");
        writer.println("07/01/2015 Taxi 41.00 G");
        writer.println("08/01/2015 Almuerzo 42.00 G");
        writer.println("09/01/2015 Gastos_Varios 43.00 G");
        writer.println("10/01/2015 Gastos_informaticos 44.00 G");
        writer.println("02/02/2015 Intereses_cuentas 1.00 I");
        writer.println("03/02/2015 Devolucion_comisiones 1.00 I");
        writer.println("04/02/2015 Loteria 1.00 I");
        writer.println("05/02/2015 Loteria 1.00 I");
        writer.println("09/01/2016 Luz 45.00 G");
        writer.println("10/01/2016 Agua 46.00 G");
        writer.println("11/01/2016 Gas 47.00 G");
        writer.println("12/01/2016 Taxi 48.00 G");
        writer.println("13/01/2016 Almuerzo 49.00 G");
        writer.println("14/01/2016 Taxi 50.00 G");
        writer.println("15/01/2016 Gastos_varios 51.00 G");
        writer.println("06/02/2016 Loteria 1.00 I");
        writer.println("07/02/2016 Devolucion_comisiones 1.00 I");
        writer.println("08/02/2016 Intereses_cuentas 1.00 I");
        writer.println("09/02/2016 Nomina 500.00 I");
        writer.println("10/02/2017 Loteria 1.00 I");
        //</editor-fold>
        
        writer.close();
        System.out.printf("El archivo creado está en %s\n", archivo.getAbsolutePath());
    }
    
    @Override
    public void crearFichero() throws FileNotFoundException, IOException
    {
        archivo.getParentFile().mkdirs();
        System.out.printf("El archivo creado está en %s\n", archivo.getAbsolutePath());
        
    }
    
    @Override
    public void empezarAEscribir() throws FileNotFoundException, IOException
    {
        this.writer = new PrintWriter(archivo, "UTF-8");
    }
    
    public void escribirEnElFichero(String linea) throws FileNotFoundException, IOException
    {  
        try
        {
            writer.println(linea);
        }
        catch(NullPointerException e)
        {
            System.err.println("\n\t\t\t\t\t\t-Solución: ANTES TIENES QUE ejecutar empezarAEscribir()- (no te olvides de llamar a terminarDeEscribir() despues)\n");
        }
        
    }
    
    public void reemplazarEnElFichero(String palabra, String reemplazo) throws IOException
    {
        Path path = Paths.get(this.ruta+this.nombre+".txt");
        Charset charset = StandardCharsets.UTF_8;

        String content = new String(Files.readAllBytes(path), charset);
        content = content.replaceAll(palabra.trim(), reemplazo.trim());
        Files.write(path, content.getBytes(charset));
    }
    
    @Override
    public void terminarDeEscribir()
    {
        writer.close();
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
		System.out.println(line+" |");
	}
 
	br.close();
    }
    
    public ArrayList<String> devolverIngresos() throws FileNotFoundException, IOException
    {
        ArrayList<String> ingresos = new ArrayList<>();
        BufferedReader br = new BufferedReader(new FileReader(this.archivo));
        
	String line = null;
	while ((line = br.readLine()) != null) {
            if (line.substring(line.length() - 1).equals("I"))
            {
                //System.out.printf("Ingreso %s añadido a la lista\n",line);
		ingresos.add(line);
            }
	}
 
	br.close();
        return ingresos;
    }
    
    public ArrayList<String> devolverGastos() throws FileNotFoundException, IOException
    {
        ArrayList<String> gastos = new ArrayList<>();
        BufferedReader br = new BufferedReader(new FileReader(this.archivo));
        
	String line = null;
	while ((line = br.readLine()) != null) {
            if (line.substring(line.length() - 1).equals("G"))
            {
                //System.out.printf("Ingreso %s añadido a la lista\n",line);
		gastos.add(line);
            }
	}
 
	br.close();
        return gastos;
    }
}
