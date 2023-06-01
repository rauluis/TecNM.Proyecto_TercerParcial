namespace TecNM.Proyecto.Core.Http;

public class Response<T>{
public T? Data {get;set;}
public string Message {get;set;}="";
public string ErrorMessage { get; set; }
public bool Success { get; set; }

public List<string> Errors{get;set;}= new List<string>();

}