#pragma strict

var material1 : Material; var material2 : Material;

function OnChangeMaterial() {    // toggle between the two materials   
 if( GetComponent.<Renderer>().material == material1 )      
 GetComponent.<Renderer>().material = material2;   else      GetComponent.<Renderer>().material = material1;

}

function Start () {
	OnChangeMaterial();
}

function Update () {

}