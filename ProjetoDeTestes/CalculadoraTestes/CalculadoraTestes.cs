using Calculadora.Services;

namespace CalculadoraTestes;

public class CalculadoraTestes
{

    private CalculadoraImplementacao _calc;

    public CalculadoraTestes()
    {
        _calc = new CalculadoraImplementacao();
    }

    [Fact]
    public void DeveSomar5Com10ERetornar15()
    {
        //Arrange - preparar os parametros pro teste 
        int num1 = 5;
        int num2 = 10;

        //Act - chamar a ação do teste
        int resultado = _calc.Somar(num1, num2);

        //Assert - verificar o resultado do metodo 
        Assert.Equal(15, resultado);
    }

    [Fact]
    public void DeveVerificarSe4EhPar()
    {
        //Arrange 
        int numero = 4;

        //Act
        bool resultado = _calc.EhPar(numero);

        //Assert 
        Assert.True(resultado);
    }

    [Theory]
    [InlineData(new int[] {2,4,6,8,10})]
    public void DeveVerificarSeSaoPares(int[] nums)
    {
        //verifica todos de uma vez só via lista
        Assert.All(nums, x => Assert.True(_calc.EhPar(x)));
    }
}