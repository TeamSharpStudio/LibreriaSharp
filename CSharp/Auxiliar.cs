using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * Repositorio GitHub: https://github.com/TeamSharpStudio/LibreriaSharp
 * Usuarios: Sergio Lucena Fernández: https://github.com/SergioLucenaFdz, Daniel Ramírez Sánchez: https://github.com/sirdan93
 * Equipo: https://github.com/TeamSharpStudio
 */

namespace LibreriaSharp

{

    #region Funciones comunes estáticas
    namespace Comunes
    {
        public static class Auxiliar
        {
            #region Funciones de entrada por teclado (Comunes)

            #region String
            public static string leerCadena(string mensaje)
            {
                string cadena;
                bool cadenaOk = false;
                #region Validación del mensaje
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tienes que introducir un valor.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    else
                    {
                        cadenaOk = true;
                    }
                } while (!cadenaOk);
                #endregion

                return cadena;
            }

            public static string leerCadenaSoloLetras(string mensaje)
            {
                string cadena;
                bool cadenaOk = false;
                #region Validación del mensaje
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tienes que introducir un valor.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    else
                    {
                        
                        if (Regex.IsMatch(cadena, @"^[a-zA-Z]+$"))
                        {
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El formato no es correcto, el valor solo puede contener letras");
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                } while (!cadenaOk);
                #endregion

                return cadena;
            }

            public static string leerCadenaSoloAlfanumericos(string mensaje)
            {
                string cadena;
                bool cadenaOk = false;
                #region Validación del mensaje
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tienes que introducir un valor.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    else
                    {

                        if (Regex.IsMatch(cadena, @"^[a-zA-Z0-9]+$"))
                        {
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El formato no es correcto, el valor solo puede contener letras y números");
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                } while (!cadenaOk);
                #endregion

                return cadena;
            }
            #endregion

            #region ArrayList
            public static ArrayList leerCadenaCrearLista(string mensaje, string elementoLista)
            {
                string cadena;
                int tamaño;
                ArrayList listaDePalabras = new ArrayList();
                bool cadenaOk = false;

                tamaño = leerEnteroPositivo("\t" + mensaje);
                #region Validación del mensaje
                for (int i = 0; i < tamaño; i++)
                {
                    do
                    {
                        Console.Write("\t\tIntroduce el {0} nº {1}: ", elementoLista, i + 1);
                        cadena = Console.ReadLine();
                        if (cadena.Equals(""))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tienes que introducir un valor.");
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                        else
                        {
                            listaDePalabras.Add(cadena);
                            cadenaOk = true;
                        }
                    } while (!cadenaOk);
                }
                #endregion

                return listaDePalabras;
            }
            #endregion

            #region Entero Positivo
            public static int leerEnteroPositivo(string mensaje)
            {
                string cadena;
                bool cadenaOk = false;
                #region Validación del mensaje
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    #region Convertir a entero
                    try
                    {
                        Convert.ToInt32(cadena);
                        cadenaOk = true;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    #endregion

                } while (!cadenaOk);
                #endregion

                return Math.Abs(Convert.ToInt32(cadena));
            }

            public static int leerEnteroPositivo(string mensaje, int min, int max)
            {
                string cadena;
                bool cadenaOk = false;
                #region Validación del mensaje
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    #region Convertir a entero
                    try
                    {
                        Convert.ToInt32(cadena);
                        if (Convert.ToInt32(cadena) >= min && Convert.ToInt32(cadena) <= max)
                        {
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El valor debe de estar comprendido entre {0} y {1}.", min, max);
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    #endregion

                } while (!cadenaOk);
                #endregion

                return Math.Abs(Convert.ToInt32(cadena));
            }

            public static int leerEnteroPositivo(string mensaje, int min, int max, string mensajeDeError)
            {
                string cadena;
                bool cadenaOk = false;
                #region Validación del mensaje
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    #region Convertir a entero
                    try
                    {
                        Convert.ToInt32(cadena);
                        if (Convert.ToInt32(cadena) >= min && Convert.ToInt32(cadena) <= max)
                        {
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0}; Las opciones van del {1} al {2}.", mensajeDeError, min, max);
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    #endregion

                } while (!cadenaOk);
                #endregion

                return Math.Abs(Convert.ToInt32(cadena));
            }
            #endregion

            #region Double Positivo

            public static double leerDoublePositivo(string mensaje)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación del mensaje

                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #region Convertir a entero

                    try
                    {
                        Convert.ToDouble(cadena);
                        cadenaOk = true;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #endregion Convertir a entero
                } while (!cadenaOk);

                #endregion Validación del mensaje

                return Math.Abs(Convert.ToDouble(cadena));
            }

            public static double leerDoublePositivo(string mensaje, double min, double max)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación del mensaje

                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #region Convertir a entero

                    try
                    {
                        Convert.ToDouble(cadena);
                        if (Convert.ToInt32(cadena) >= min && Convert.ToDouble(cadena) <= max)
                        {
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El valor debe de estar comprendido entre {0} y {1}.", min, max);
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #endregion Convertir a entero
                } while (!cadenaOk);

                #endregion Validación del mensaje

                return Math.Abs(Convert.ToDouble(cadena));
            }

            public static double leerDoublePositivo(string mensaje, double min, double max, string mensajeDeError)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación del mensaje

                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #region Convertir a entero

                    try
                    {
                        Convert.ToDouble(cadena);
                        if (Convert.ToInt32(cadena) >= min && Convert.ToDouble(cadena) <= max)
                        {
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0}; Las opciones van del {1} al {2}.", mensajeDeError, min, max);
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #endregion Convertir a entero
                } while (!cadenaOk);

                #endregion Validación del mensaje

                return Math.Abs(Convert.ToDouble(cadena));
            }

            #endregion

            #region Byte Positivo

            public static byte leerBytePositivo(string mensaje)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación del mensaje

                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #region Convertir a entero

                    try
                    {
                        Convert.ToByte(cadena);
                        cadenaOk = true;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #endregion Convertir a entero
                } while (!cadenaOk);

                #endregion Validación del mensaje

                return Convert.ToByte(cadena);
            }

            public static byte leerBytePositivo(string mensaje, byte min, byte max)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación del mensaje

                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #region Convertir a entero

                    try
                    {
                        Convert.ToByte(cadena);
                        if (Convert.ToByte(cadena) >= min && Convert.ToByte(cadena) <= max)
                        {
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El valor debe de estar comprendido entre {0} y {1}.", min, max);
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #endregion Convertir a entero
                } while (!cadenaOk);

                #endregion Validación del mensaje

                return Convert.ToByte(cadena);
            }

            public static byte leerBytePositivo(string mensaje, byte min, byte max, string mensajeDeError)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación del mensaje

                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero no puede estar vacío");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #region Convertir a entero

                    try
                    {
                        Convert.ToByte(cadena);
                        if (Convert.ToByte(cadena) >= min && Convert.ToByte(cadena) <= max)
                        {
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0}; Las opciones van del {1} al {2}.", mensajeDeError, min, max);
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor debe de ser numérico.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor es demasiado grande.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }

                    #endregion Convertir a entero
                } while (!cadenaOk);

                #endregion Validación del mensaje

                return Convert.ToByte(cadena);
            }

            #endregion

            #region Dni
            public static string leerDni(string mensaje)
            {
                string cadena;
                bool cadenaOk = false;
                #region Validación del dni
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();
                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tienes que introducir un valor en el dni.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    else if (!comprobarDNI(cadena))
                    {
                        if (Regex.Match(cadena.Trim(), @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$").Success)
                        {
                            cadena = calcularLetraDni(cadena);
                            cadenaOk = true;
                        }
                        else if (Regex.Match(cadena.Trim(), @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][a-zA-Z]$").Success)
                        {
                            cadena = calcularLetraDni(cadena);
                            cadenaOk = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El formato del dni no es correcto.");
                            Console.ResetColor();
                            cadenaOk = false;
                        }
                    }
                    else
                    {
                        cadenaOk = true;
                    }
                } while (!cadenaOk);
                #endregion

                return cadena;
            }
            #endregion

            #region Fecha
            public static string leerFecha(string mensaje)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación del mensaje
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();


                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La fecha no puede estar vacía.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    else
                    {
                        if (Regex.IsMatch(cadena.Trim(), @"^[0-9][0-9]/[0-9][0-9]/[0-9][0-9][0-9][0-9]$"))
                        {
                            string[] fecha = cadena.Split('/');
                            bool diaOk = false, mesOk = false;
                            cadenaOk = false;
                            if (Convert.ToInt32(fecha[0]) < 32 && Convert.ToInt32(fecha[0]) > 0)
                            {
                                diaOk = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El día es incorrecto (Los días van del 1 al 31)");
                                Console.ResetColor();
                            }

                            if (Convert.ToInt32(fecha[1]) < 13 && Convert.ToInt32(fecha[1]) > 0)
                            {
                                mesOk = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El mes es incorrecto (Los meses van del 1 al 12)");
                                Console.ResetColor();
                            }

                            if (diaOk && mesOk)
                            {
                                cadenaOk = true;
                            }
                            else
                            {
                                cadenaOk = false;
                            }
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El formato de la fecha es incorrecto; El formato correcto es: dd/mm/aaaa");
                            Console.ResetColor();
                        }
                    }
                } while (!cadenaOk) ;
                #endregion

                    return cadena;
            }
            public static string leerFecha(string mensaje, int añoMin)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación del mensaje
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();

                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La fecha no puede estar vacía.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    else
                    {
                        if (Regex.IsMatch(cadena.Trim(), @"^[0-9][0-9]/[0-9][0-9]/[0-9][0-9][0-9][0-9]$"))
                        {
                            #region Validación de meses, dias años
                            string[] fecha = cadena.Split('/');
                            if (Convert.ToInt32(fecha[2]) >= añoMin && Convert.ToInt32(fecha[2]) >= añoMin)
                            {
                                bool diaOk = false, mesOk = false;
                                cadenaOk = false;
                                if (Convert.ToInt32(fecha[0]) < 32 && Convert.ToInt32(fecha[0]) > 0)
                                {
                                    diaOk = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El día es incorrecto (Los días van del 1 al 31)");
                                    Console.ResetColor();
                                }

                                if (Convert.ToInt32(fecha[1]) < 13 && Convert.ToInt32(fecha[1]) > 0)
                                {
                                    mesOk = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El mes es incorrecto (Los meses van del 1 al 12)");
                                    Console.ResetColor();
                                }

                                if (diaOk && mesOk)
                                {
                                    cadenaOk = true;
                                }
                                else
                                {
                                    cadenaOk = false;
                                }
                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El año mínimo es: {0}",añoMin);
                                Console.ResetColor();
                                cadenaOk = false;
                            }
                            #endregion
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El formato de la fecha es incorrecto; El formato correcto es: dd/mm/aaaa (Asegúrate de rellenar con ceros)");
                            Console.ResetColor();
                        }
                    }
                } while (!cadenaOk);
                #endregion

                return cadena;

            }
            public static string leerFecha(string mensaje, int añoMin, int añoMax)
            {
                string cadena;
                bool cadenaOk = false;

                #region Validación de la fecha
                do
                {
                    Console.Write("{0}: ", mensaje);
                    cadena = Console.ReadLine();

                    if (cadena.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La fecha no puede estar vacía.");
                        Console.ResetColor();
                        cadenaOk = false;
                    }
                    else
                    {
                        if (Regex.IsMatch(cadena.Trim(), @"^[0-9][0-9]/[0-9][0-9]/[0-9][0-9][0-9][0-9]$"))
                        {
                            #region Validación de meses, dias años
                            string[] fecha = cadena.Split('/');
                            if (Convert.ToInt32(fecha[2]) >= añoMin && Convert.ToInt32(fecha[2]) <= añoMax)
                            {
                                bool diaOk = false, mesOk = false;
                                cadenaOk = false;
                                if (Convert.ToInt32(fecha[0]) < 32 && Convert.ToInt32(fecha[0]) > 0)
                                {
                                    diaOk = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El día es incorrecto (Los días van del 1 al 31)");
                                    Console.ResetColor();
                                }

                                if(Convert.ToInt32(fecha[1]) < 13 && Convert.ToInt32(fecha[1]) > 0)
                                {
                                    mesOk = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El mes es incorrecto (Los meses van del 1 al 12)");
                                    Console.ResetColor();
                                }

                                if (diaOk && mesOk)
                                {
                                    cadenaOk = true;
                                }
                                else
                                {
                                    cadenaOk = false;
                                }
                                #endregion
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El año mínimo es: {0}, el máximo es: {1}", añoMin, añoMax);
                                Console.ResetColor();
                                cadenaOk = false;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El formato de la fecha es incorrecto; El formato correcto es: dd/mm/aaaa (Asegúrate de rellenar con ceros)");
                            Console.ResetColor();
                        }
                    }
                } while (!cadenaOk);
                #endregion

                return cadena;

            }
            #endregion

            #endregion

            #region Funciones de salida por pantalla (Comunes)
            public static void WriteLineColor(string valor, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(valor);
                Console.ResetColor();
            }

            public static void WriteLineColor(string valor, ConsoleColor color, ConsoleColor colorPorDefecto)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(valor);
                Console.ForegroundColor = colorPorDefecto;
            }

            public static decimal truncarDecimal(decimal value, int precision)
            {
                decimal step = (decimal)Math.Pow(10, precision);
                int tmp = (int)Math.Truncate(step * value);
                return tmp / step;
            }
            #endregion

            #region Funciones de comprobación (Comunes)

            private static bool comprobarDNI(string dni)
            {
                if (Regex.Match(dni.Trim(), @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][a-zA-Z]$").Success)
                {
                    int numeroDni = Convert.ToInt32(dni.Trim().Substring(0, 8));
                    char letraDni = Convert.ToChar(dni.Trim().Substring(8));
                    string juegoCaracteres = "TRWAGMYFPDXBNJZSQVHLCKE";
                    int modulo = numeroDni % 23;
                    char letra = juegoCaracteres[modulo];
                    if (letraDni.Equals(letra))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            #endregion

            #region Funciones de cálculo (Comunes)

            public static string calcularLetraDni(string dni)
            {
                if (Regex.Match(dni.Trim(), @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$").Success)
                {
                    string juegoCaracteres = "TRWAGMYFPDXBNJZSQVHLCKE";
                    int modulo = Convert.ToInt32(dni) % 23;
                    char letra = juegoCaracteres[modulo];

                    string dniBueno = dni + letra;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("La letra del dni {0} es {1}, por lo tanto el dni se ha cambiado a {2}", dni, letra, dniBueno);
                    Console.ResetColor();
                    return dniBueno.Trim();
                }
                else if (Regex.Match(dni.Trim(), @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][a-zA-Z]$").Success)
                {
                    string juegoCaracteres = "TRWAGMYFPDXBNJZSQVHLCKE";

                    int modulo = Convert.ToInt32(dni.Trim().Substring(0, 8)) % 23;
                    char letra = juegoCaracteres[modulo];

                    string dniBueno = dni.Trim().Substring(0, 8) + letra;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("La letra del dni {0} es {1}, por lo tanto el dni se ha cambiado a {2}", dni, letra, dniBueno);
                    Console.ResetColor();
                    return dniBueno.Trim();
                }
                else
                {
                    return null;
                }
            }

            #endregion

            #region Funciones de salida del programa (Comunes)

            public static bool salir(string pregunta)
            {
                string respuesta;
                Console.ResetColor();
                Console.WriteLine("\n{0}: ", pregunta);
                respuesta = Console.ReadLine().ToLower();
                switch (respuesta)
                {
                    case "s":
                        return true;

                    default:
                        return false;
                }
            }

            #endregion

            #region Funciones de sonido consola (Comunes)

            public static void emitirUnPitido(string mensaje)
            {
                Console.Beep();
                Console.WriteLine(mensaje);
            }

            public static void emitirTresPitidos(string mensaje)
            {
                Console.Beep(); Console.Beep(); Console.Beep();
                Console.WriteLine(mensaje);
            }

            #endregion

        } // Clase estática de funciones comunes
    }
    #endregion

    #region Menús
    namespace Menu
    {
        #region Clases Base
        abstract class Menu
        {
            string nombre;
            int numDeItems;
            List<string> items;

            #region Propiedades
            public string Nombre
            {
                get
                {
                    return nombre;
                }
            }
            public int NumDeItems
            {
                get
                {
                    return numDeItems;
                }
            }
            public List<string> Items
            {
                get
                {
                    return items;
                }
            }
            #endregion

            public Menu(string nombre, int numDeItems)
            {
                this.nombre = nombre;
                this.numDeItems = numDeItems;
                items = new List<string>();

                for (int i = 0; i < NumDeItems; i++)
                {
                    items.Add(LibreriaSharp.Comunes.Auxiliar.leerCadena("Escriba el item nº" + (i + 1)));
                }
            }

            public abstract int elegirOpcion();
        } // Clase base de todos los menús

        abstract class MenuEstatico
        {
            string nombre;
            int numDeItems;
            List<string> items;

            #region Propiedades
            public string Nombre
            {
                get
                {
                    return nombre;
                }
            }
            public int NumDeItems
            {
                get
                {
                    return numDeItems;
                }
            }
            public List<string> Items
            {
                get
                {
                    return items;
                }
            }
            #endregion

            public MenuEstatico(string nombre)
            {
                this.nombre = nombre;
                this.numDeItems = numDeItems;
                items = new List<string>();
            }

            public abstract int elegirOpcion();
        } // Clase base de todos los menús estáticos
        #endregion

        #region Menús personalizados (Todos deben heredar de Menu)
        class MenuCustom : Menu // Menú custom de prueba
        {
            public MenuCustom(string nombre, int numDeItems) : base(nombre, numDeItems)
            {
            }

            public override int elegirOpcion()
            {
                Console.WriteLine("\n------{0}------\n", Nombre.ToUpper());
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine("\t{0}. {1}", i + 1, Items[i]);
                }
                Console.WriteLine("---------------\n\n");

                int opcion = LibreriaSharp.Comunes.Auxiliar.leerEnteroPositivo("Elija la opción", 1, Items.Count);

                return opcion;
            }
        } // Clase que hereda de menú

        class MenuBaseDeDatos : MenuEstatico // Menú de la base de datos
        {
            public MenuBaseDeDatos(string nombre) : base(nombre)
            {
                Items.Add("Libros");
                Items.Add("Libros con volumen");
                Items.Add("Revistas");
                Items.Add("DVD's");
                Items.Add("Salir");
            }

            public override int elegirOpcion()
            {
                Console.WriteLine("\n\t------{0}------", Nombre.ToUpper());
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine("\t\t{0}. {1}", i + 1, Items[i]);
                }
                Console.WriteLine("\t--------------------------\n\n");

                int opcion = LibreriaSharp.Comunes.Auxiliar.leerEnteroPositivo("Elija la opción", 1, Items.Count);

                return opcion;
            }
        } // Clase que hereda de menú estático
        #endregion
    }
    #endregion

    #region Bases de Datos
    namespace BD
    {
        public abstract class BaseDeDatos
        {
            string nombre;
            int numeroDeTablas;
            List<ArrayList> bD;

            #region Propiedades
            public string Nombre
            {
                get
                {
                    return nombre;
                }
            }
            public int NumeroDeTablas
            {
                get
                {
                    return numeroDeTablas;
                }
            }
            public List<ArrayList> BD
            {
                get
                {
                    return bD;
                }
            }
            #endregion

            public BaseDeDatos(string nombre, int numeroDeTablas)
            {
                this.nombre = nombre;
                this.numeroDeTablas = numeroDeTablas;

                bD = new List<ArrayList>(numeroDeTablas);

                Console.WriteLine("Creada la base de datos {0} con {1} tabla(s)", Nombre, NumeroDeTablas);
            }

            public abstract List<ArrayList> devuelveTodasLasTablas();

        } // Clase para crear Bases de Datos Nuevas

        /*public class BaseDeDatosBiblioteca : BaseDeDatos
        {
            #region Tablas de la biblioteca
            ArrayList libros;
            ArrayList librosVol;
            ArrayList revistas;
            ArrayList dvds;
            #endregion

            #region Propiedades
            public ArrayList Libros
            {
                get
                {
                    return libros;
                }
            }
            public ArrayList LibrosVol
            {
                get
                {
                    return librosVol;
                }
            }
            public ArrayList Revistas
            {
                get
                {
                    return revistas;
                }
            }
            public ArrayList Dvds
            {
                get
                {
                    return dvds;
                }
            }
            #endregion

            public BaseDeDatosBiblioteca(string nombre, int numeroDeTablas) : base(nombre, numeroDeTablas)
            {
                libros = new ArrayList();
                librosVol = new ArrayList();
                revistas = new ArrayList();
                dvds = new ArrayList();

                base.BD.Add(Libros);
                base.BD.Add(LibrosVol);
                base.BD.Add(Revistas);
                base.BD.Add(Dvds);
            }

            #region Inserciones
            public void añadirLibro(FichaLibro libro)
            {
                base.BD[0].Add(libro);
            }

            public void añadirLibroVol(FichaLibroVol libroVol)
            {
                base.BD[1].Add(libroVol);
            }

            public void añadirRevista(FichaRevista revista)
            {
                base.BD[2].Add(revista);
            }

            public void añadirDvd(FichaDVD dvd)
            {
                base.BD[3].Add(dvd);
            }
            #endregion

            #region Consultas
            public int cuentaLibros()
            {
                int i = 0;
                var consultaLibros = from FichaLibro libros in BD[0]
                                     select libros;

                foreach (FichaLibro l in consultaLibros)i++;

                return i;
            }
            public int cuentaLibrosVol()
            {
                int i = 0;
                var consultaLibrosVol = from FichaLibroVol librosVol in BD[1]
                                     select librosVol;

                foreach (FichaLibroVol lv in consultaLibrosVol) i++;

                return i;
            }
            public int cuentaRevistas()
            {
                int i = 0;
                var consultaRevistas = from FichaRevista revistas in BD[2]
                                     select revistas;

                foreach (FichaRevista r in consultaRevistas) i++;

                return i;
            }
            public int cuentaDvds()
            {
                int i = 0;
                var consultaDvds = from FichaDVD dvds in BD[3]
                                     select dvds;

                foreach (FichaDVD d in consultaDvds) i++;

                return i;
            }

            public void imprimirLibros()
            {
                var consultaLibros = from FichaLibro libros in BD[0]
                                     select libros;

                foreach (FichaLibro f in consultaLibros)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    f.imprimir();
                    Console.ResetColor();
                }
            }
            public void imprimirLibrosVol()
            {
                var consultaLibrosVol = from FichaLibroVol librosVol in BD[1]
                                        select librosVol;

                foreach (FichaLibroVol f in consultaLibrosVol)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    f.imprimir();
                    Console.ResetColor();
                }
            }
            public void imprimirRevistas()
            {
                var consultaRevistas = from FichaRevista revistas in BD[2]
                                       select revistas;

                foreach (FichaRevista f in consultaRevistas)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    f.imprimir();
                    Console.ResetColor();
                }
            }
            public void imprimirDvds()
            {
                var consultaDvds = from FichaDVD dvds in BD[3]
                                   select dvds;

                foreach (FichaDVD f in consultaDvds)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    f.imprimir();
                    Console.ResetColor();
                }
            }
            #endregion

            public override List<ArrayList> devuelveTodasLasTablas()
            {
                return base.BD;
            }


        } */// Base de datos de la biblioteca (Comentada)
    }
    #endregion

}