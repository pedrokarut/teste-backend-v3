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
}