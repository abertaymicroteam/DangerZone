using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IndicatorManager : MonoBehaviour {

	//Containers
    public GameObject IndicatorPrefab;
    Canvas canvas;
	Camera cam;
	bool drawIndicator; // Decides whether to draw the indicator for each object

	// List for storing active indicators
	List<GameObject> Indicators = new List<GameObject> ();
	int currIndicator = 0;

	// Script containers
	DirectProjectileMovementScript tempDirectScript;
	ArcedProjectileMovement tempArcScript;

	// Use this for initialization
	void Start ()
    {
        // Get canvas
        canvas = GameObject.FindObjectOfType(typeof(Canvas)) as Canvas;
		// Get camera
		cam = GameObject.Find("Camera (eye)").GetComponent<Camera>();

		// Init containers
		drawIndicator = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		// Reset iterator
		currIndicator = 0;

        // Array holding all current projectiles
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");

        foreach(GameObject obj in projectiles)
        {
            // Get position in screen space
            Vector3 screenPos = cam.WorldToScreenPoint(obj.transform.position);

			// Check if indicator should be drawn for this object
			if (obj.GetComponent<DirectProjectileMovementScript> () != null) 
			{
				tempDirectScript = obj.GetComponent<DirectProjectileMovementScript> ();

				if (tempDirectScript.showIndicator == true) 
				{
					drawIndicator = true;
				} 
				else 
				{
					drawIndicator = false;
				}
			} 
			else 
			{ // object is arced
				tempArcScript = obj.GetComponent<ArcedProjectileMovement>();

				if (tempArcScript.showIndicator == true) 
				{
					drawIndicator = true;
				} 
				else 
				{
					drawIndicator = false;
				}
			}

            // Check if in screen space and that indicator should be shown
            if ((screenPos.z < 0 ||
                screenPos.y < 0 && screenPos.y > Screen.height ||
				screenPos.x < 0 && screenPos.x > Screen.width)
				&& (drawIndicator == true ))
            { // Projectile is off screen and should be drawn
                
                // Get screen centre
                Vector3 centre = new Vector3(Screen.width, Screen.height, 0) / 2;

                // Offset screen pos by centre to put (0, 0) at the centre of screen rather than bottom left
                screenPos -= centre;

				// Find angle for indicator rotation
				float angle =  Mathf.Atan2(screenPos.y, screenPos.x) + 90.0f;
				angle *= Mathf.Rad2Deg;

                // If object is behind us
                if (screenPos.z < 0)
                { // Flip screenPos
                    screenPos = (screenPos * -1);
					angle -= 180.0f;
                }

                // Calculate gradient using screen position
                float m = screenPos.y / screenPos.x;

                // Bring screen bounds in by a tenth
                Vector3 screenBounds = centre * 0.5f;

                // Which side of the screen is it off?                
                if (screenPos.y > 0)
                {// Up
                    screenPos = new Vector3(screenBounds.y / m, screenBounds.y, 0);
                }
                else
                {// Down
                    screenPos = new Vector3(-screenBounds.y / m, -screenBounds.y, 0);
                }
                if (screenPos.x > screenBounds.x)
                {// Right
                    screenPos = new Vector3(screenBounds.x, screenBounds.x * m, 0);
                }
                else if (screenPos.x < (-screenBounds.x))
                {// Left
                    screenPos = new Vector3(-screenBounds.x, -screenBounds.x * m, 0);
                }
                else
                {
                    // Object is in bounds on X
                }

                // We now have the position in screen space to instantiate our indicator
				GameObject newIndicator = GetIndicator(); // 
				newIndicator.transform.localPosition = screenPos;
				newIndicator.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, angle);
            }
        }

		// refresh indicator list
		ClearList ();
	}

	GameObject GetIndicator()
	{// gets next existing indicator, if none creates a new one

		GameObject output;

		if (currIndicator < Indicators.Count)
		{ // get next
			output = Indicators[currIndicator];
		}
		else 
		{ // create new
			output = (GameObject) Instantiate(IndicatorPrefab) as GameObject;
			output.transform.SetParent(canvas.transform, true);
			Indicators.Add (output);
		}

		currIndicator++;
		return output;			
	}

	void ClearList()
	{
		// Deletes unused indicators
		while (Indicators.Count > currIndicator)
		{
			GameObject obj = Indicators [Indicators.Count - 1]; // Get last indicator in list
			Indicators.Remove (obj);
			Destroy (obj.gameObject);
		}
	}
}
