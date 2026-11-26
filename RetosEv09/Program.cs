using System;

// ==========================================
// RETO INTERFACES: IMediaPlayer & MusicPlayer
// ==========================================
public interface IMediaPlayer
{
    void Play();
    void Pause();
    void Stop();
    string GetCurrentTrack();
}

public class MusicPlayer : IMediaPlayer
{
    private string current_track = string.Empty;

    public void LoadTrack(string track_name)
    {
        current_track = track_name;
        Console.WriteLine($"Pista cargada: {current_track}");
    }

    public void Play()
    {
        if (string.IsNullOrWhiteSpace(current_track))
        {
            Console.WriteLine("No hay ninguna pista cargada para reproducir.");
            return;
        }
        Console.WriteLine($"Reproduciendo: {current_track}");
    }

    public void Pause()
    {
        if (string.IsNullOrWhiteSpace(current_track))
        {
            Console.WriteLine("No hay ninguna pista cargada para pausar.");
            return;
        }
        Console.WriteLine("Pista en pausa");
    }

    public void Stop()
    {
        if (string.IsNullOrWhiteSpace(current_track))
        {
            Console.WriteLine("No hay ninguna pista activa para detener.");
            return;
        }
        Console.WriteLine("Reproducción detenida");
        current_track = string.Empty;
    }

    public string GetCurrentTrack()
    {
        return string.IsNullOrWhiteSpace(current_track)
            ? "Sin pista"
            : current_track;
    }
}

// ==========================================
// RETO EXCEPCIONES: EdadInvalidaException
// ==========================================
public class EdadInvalidaException : Exception
{
    public EdadInvalidaException(string mensaje) : base(mensaje)
    {
    }
}

class Program
{
    static void ValidarEdad(int edad)
    {
        if (edad < 0 || edad > 120)
        {
            throw new EdadInvalidaException($"La edad {edad} está fuera del rango permitido (0 a 120 años).");
        }
    }

    static void EjecutarRetoExcepciones()
    {
        Console.WriteLine("\n==========================================");
        Console.WriteLine("== Reto Excepciones ==");
        Console.WriteLine("==========================================");
        Console.Write("Ingrese su edad -> ");
        string entrada = Console.ReadLine() ?? string.Empty;

        try
        {
            int edad = int.Parse(entrada);
            ValidarEdad(edad);
            Console.WriteLine($"Edad válida: {edad} años.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: debe ingresar un número entero válido.");
        }
        catch (EdadInvalidaException ex)
        {
            Console.WriteLine($"Error de validación: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("== Proceso de validación finalizado ==");
        }
    }

    static void EjecutarRetoInterfaces()
    {
        Console.WriteLine("\n==========================================");
        Console.WriteLine("== Reto Interfaces ==");
        Console.WriteLine("==========================================");

        IMediaPlayer reproductor = new MusicPlayer();
        MusicPlayer playerConcreto = (MusicPlayer)reproductor;

        Console.WriteLine($"Estado inicial: {reproductor.GetCurrentTrack()}");

        Console.Write("Ingrese la siguiente canción -> ");
        string cancion = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(cancion))
        {
            cancion = "Canción de prueba";
        }

        playerConcreto.LoadTrack(cancion);
        reproductor.Play();
        reproductor.Pause();
        reproductor.Stop();
        Console.WriteLine($"Estado final: {reproductor.GetCurrentTrack()}");
    }

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("== Ingreso a la EV09 - Interfaces y manejo de excepciones ==");
            Console.WriteLine("==========================================");
            Console.WriteLine("== ¿Qué operación desea realizar? ==");
            Console.WriteLine("1. Ingresar al Reto de Excepciones");
            Console.WriteLine("2. Ingresar al Reto de Interfaces");
            Console.WriteLine("0. Salir");
            Console.Write("Digite el número -> ");

            string opcion = (Console.ReadLine() ?? string.Empty).Trim();

            switch (opcion)
            {
                case "1":
                    EjecutarRetoExcepciones();
                    break;
                case "2":
                    EjecutarRetoInterfaces();
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("\nSaliendo de EV09...");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}