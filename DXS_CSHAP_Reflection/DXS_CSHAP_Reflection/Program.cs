﻿using DXS_CSHAP_Reflection;
using System.Text;

/*
PARA POR EM PRÁTICA O CONCEITO DE REFLECTION VAMOS:
CRIAR DUAS CLASSES DE CADASTRO DE CLIENTES, PESSOA FISICA E JURIDICA, TEMOS SOMENTE O CAMPO DE DOCUMENTAÇÃO DE DIFERENTE ENTRE AS CLASSES.
VAMOS SUBISTITUIR TODAS AS INFORMAÇÕES DA EMPRESA REMOVIDA COM AS INFORMAÇÕES DA PESSOA FISICA QUE SÃO COMPATIVEIS ENTRE ELAS.
 */
var pessoaA = new Pessoa_fisica {  //pessoa fisica criada e carregada
    id = 12,
    nome = "Marcos Waldelino",
    cpf = "06191846045"
};
var pessoaB = new Pessoa_juridica { //pessoa juridica criada e carregada
    id = 113,
    nome = "Empresa removida",
    cnpj = "99519883000108"
};  

var propriedadesA = pessoaA.GetType().GetProperties();  //carregamos um array com as propriedades da pessoa fisica

foreach (var propriedadeA in propriedadesA) {  //percorremos o array com as propriedades da pessoa fisisca 
    
    var propriedadeDeB = pessoaB.GetType().GetProperty(propriedadeA.Name);  //seleciona a propriedade de pessoa juridica que tem o mesmo nome da de pessoa fisica
    
    if(propriedadeDeB != null) {  //se encontrou a prorpiedade em pessoa juridica igual a de pessoa fisica então:
        propriedadeDeB.SetValue(pessoaB, propriedadeA.GetValue(pessoaA));  //seta a propriedade selecionada do objeto pessoa juridica igual ao valor da pessoa fisica
    }
}

string log(object objetoQualquerRecebido) {  //METODO DE LOG DAS INFORMAÇÕES USANDO REFLECTION
    var tipo = objetoQualquerRecebido.GetType();
    var construirLog = new StringBuilder();
    construirLog.AppendLine(":::Data do log: " + DateTime.Now + " | " + objetoQualquerRecebido.GetType() + ":::");
    foreach(var propriedadeAtual in tipo.GetProperties()) {
        construirLog.AppendLine(propriedadeAtual.Name + " : " + propriedadeAtual.GetValue(objetoQualquerRecebido));
    }
    return construirLog.ToString();
}   

//RESULTADO
Console.WriteLine(log(pessoaA));
Console.WriteLine(log(pessoaB));
Console.ReadKey();