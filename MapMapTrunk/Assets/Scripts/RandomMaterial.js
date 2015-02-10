#pragma strict

var material1 : Material; var material2 : Material;

function OnChangeMaterial() {    // toggle between the two materials   
 if( renderer.material == material1 )      
 renderer.material = material2;   else      renderer.material = material1;

}

function Start () {
	OnChangeMaterial();
}

function Update () {

}