#pragma strict

var hit: RaycastHit;

function Start () {

}

function Update () {
	Debug.DrawRay(transform.position, transform.forward * 10, Color.blue);
	if (Physics.Raycast(transform.position, transform.forward, hit, 10)) {
		print("There is a " + hit.transform.name + " directly ahead");
	} else {
		print("There is nothing directly ahead");
	}
	// transform.Translate(transform.forward * Time.deltaTime);
}