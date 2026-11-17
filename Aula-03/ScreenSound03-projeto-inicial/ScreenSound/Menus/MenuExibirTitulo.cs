namespace Alura.ScreenSound.Menus;

public static class MenuExibirTitulo
{
    public static void ExibirTitulo(string titulo, bool spaceBelow)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '=');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos);
        if (spaceBelow)
        {
            Console.WriteLine("");
        }
    }
}
