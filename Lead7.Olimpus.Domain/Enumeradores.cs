namespace Lead7.Olimpus.Domain
{
    public enum TipoObjeto
    {
        Tela,
        Agrupador,
        Campo,
        Modulo,
        Menu,
        Botao
    }

    public enum TipoAgrupador
    {
        Accordion,
        Tab
    }

    public enum TipoCampo
    {
        TextBox,
        TextArea,
        DropDown,
        Radio,
        Button,
        Password,
        Calendar
    }

    public enum Status
    {
        Ativo = 1,
        Inativo,
        Desabilitado
    }
}