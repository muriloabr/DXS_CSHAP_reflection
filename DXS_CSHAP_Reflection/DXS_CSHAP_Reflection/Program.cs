using DXS_CSHAP_Reflection;
using System.Text;

/*
PARA POR EM PRÁTICA O CONCEITO DE SYSTEM.REFLECTION VAMOS:
CRIAR DUAS CLASSES DE CADASTRO DE CLIENTES, PESSOA FISICA E JURIDICA,
TEMOS SOMENTE O CAMPO DE DOCUMENTAÇÃO DE DIFERENTE ENTRE AS CLASSES.
VAMOS SUBISTITUIR TODAS AS INFORMAÇÕES DA EMPRESA REMOVIDA
COM AS INFORMAÇÕES DA PESSOA FISICA QUE SÃO COMPATIVEIS ENTRE ELAS.
E MOSTRAR OS RESULTADOS 
 */
try {
    var pessoaA = new Pessoa_fisica {  //pessoa fisica criada e carregada
        Id = 12,
        Nome = "Marcos Waldelino",
        Cpf = "06191846045"
    };
    var pessoaB = new Pessoa_juridica { //pessoa juridica criada e carregada
        Id = 113,
        Nome = "Empresa removida",
        Cnpj = "99519883000108"
    };

    Console.WriteLine(":::::::::::::::EXIBINDO AS PESSOAS ANTES DOS PROCEDIMENTOS::::::::::::::::::::");
    Console.WriteLine(log(pessoaA));
    Console.WriteLine(log(pessoaB));

    //REFLETINDO AS PROPRIEDADES IGUAIS DE DOIS OBJETOS
    var propriedadesA = pessoaA.GetType().GetProperties();  //carregamos um array com as propriedades da pessoa fisica

    foreach (var propriedadeA in propriedadesA) {  //percorremos o array com as propriedades da pessoa fisisca 

        var propriedadeDeB = pessoaB.GetType().GetProperty(propriedadeA.Name);  //seleciona a propriedade de pessoa juridica que tem o mesmo nome da de pessoa fisica

        if (propriedadeDeB != null) {  //se encontrou a prorpiedade em pessoa juridica igual a de pessoa fisica então:
            propriedadeDeB.SetValue(pessoaB, propriedadeA.GetValue(pessoaA));  //seta a propriedade selecionada do objeto pessoa juridica igual ao valor da pessoa fisica
        }
    }

    string logExibirEstruturaDoObjeto(object objetoQualquerRecebido) {  //metodo que lê a estrutura interna da classe do objeto passado
        var tipo = objetoQualquerRecebido.GetType();
        var construirLog = new StringBuilder();
        //LENDO A CLASSE
        construirLog.AppendLine($":::MAPA DO CLASSE: {objetoQualquerRecebido.GetType()}:::");  //cadeia de caracteres interpolada
        //LENDO AS PROPRIEDADES
        foreach (var propriedadeAtual in tipo.GetProperties()) {  //SYSTEM.REFLECTION pegando as propriedades do tipo do objeto recebido
            construirLog.AppendLine($"{propriedadeAtual.Name} : {propriedadeAtual.GetValue(objetoQualquerRecebido)}");
            //cadeia de caracteres interpolada + SYSTEM.REFLECTION lendo o nome da propriedade contido na classe do objeto e lendo o valor da mesma propriedade dentro do objeto recebido  
        }
        //LENDO OS METODOS
        foreach (var metodoAtual in tipo.GetMethods()) {  //SYSTEM.REFLECTION pegando os metodos do tipo do objeto recebido
            construirLog.AppendLine($"- METODO: {metodoAtual.Name} :"); //cadeia de caracteres interpolada + SYSTEM.REFLECTION lendo o nome do metodo contido na classe do objeto
            if (metodoAtual.GetParameters().Length > 0) {
                //LENDO OS PARAMETROS DO METODO
                foreach (var parametroAtual in metodoAtual.GetParameters()) { 
                    construirLog.AppendLine($"   PARAMETRO: {parametroAtual.Name} : {parametroAtual.GetType()}"); //cadeia de caracteres interpolada + SYSTEM.REFLECTION lendo o nome do parametro do metodo contido na classe do objeto
                }
            } else {
                construirLog.AppendLine("   [NENHUM PARAMETRO]");
            }
            construirLog.AppendLine("");
        }
        construirLog.AppendLine(":::::::::");
        return construirLog.ToString();
    }

    string log(object objetoQualquerRecebido) {  //METODO DE LOG DAS INFORMAÇÕES USANDO O CONCEITO DO SYSTEM.REFLECTION
        var tipo = objetoQualquerRecebido.GetType();
        var construirLog = new StringBuilder();
        construirLog.AppendLine($":::Data do log: {DateTime.Now} | {objetoQualquerRecebido.GetType()}:::");  //cadeia de caracteres interpolada
        foreach (var propriedadeAtual in tipo.GetProperties()) {  //SYSTEM.REFLECTION pegando as propriedades do tipo do objeto recebido
            construirLog.AppendLine($"{propriedadeAtual.Name} : {propriedadeAtual.GetValue(objetoQualquerRecebido)}");
            //cadeia de caracteres interpolada + SYSTEM.REFLECTION lendo o nome da propriedade contido na classe do objeto e lendo o valor da mesma propriedade dentro do objeto recebido  
        }
        return construirLog.ToString(); //retornando o log preenchido
    }

    //RESULTADO
    Console.WriteLine(":::::::::::::::EXIBINDO AS PESSOAS DEPOIS DOS PROCEDIMENTOS::::::::::::::::::::");
    Console.WriteLine(log(pessoaA));
    Console.WriteLine(log(pessoaB));
    Console.ReadKey();
    Console.WriteLine(":::::::::::::::EXIBINDO A ESTRUTURA DAS CLASSES::::::::::::::::::::");
    Console.WriteLine(logExibirEstruturaDoObjeto(pessoaA));
    Console.WriteLine(logExibirEstruturaDoObjeto(pessoaB));
    Console.ReadKey();
    pessoaB.Limpar();
    Console.WriteLine("::::::::::::::::::::::::LIMPANDO PESSOA JURIDICA::::::::::::::::::::::::::::");
    Console.WriteLine(log(pessoaB));
    Console.ReadKey();

} catch (ExceptionManipulacaoDados ex) {  //caso for nosso erro criado por parametros errados
    Console.WriteLine($"Você errou: {ex.Message}");
} catch (Exception ex) {  //caso for erro inesperado
    Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
}
