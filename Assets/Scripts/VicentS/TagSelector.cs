using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Elevator))]
public class TagSelector : Editor{

    List<string> tags = new List<string>() { "Player, Tripulante, TripulanteAlien", "TripulanteIngeniera", "Droide", "Robot" };

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Elevator ascensor = (Elevator)target;

        GUILayout.BeginVertical();
        GUILayout.Space(5);
        GUILayout.Label("Tag de subida");
        if (GUILayout.Toggle(false, "Tripulante"))
            ascensor.CambiarTagSubir("Tripulante");
        if (GUILayout.Toggle(false, "Dcotor"))
            ascensor.CambiarTagSubir("Doctor");
        if (GUILayout.Toggle(false, "TripulanteAlien"))
            ascensor.CambiarTagSubir("TripulanteAlien");
        if (GUILayout.Toggle(false, "TripulanteIngeniera"))
            ascensor.CambiarTagSubir("TripulanteIngeniera");
        if (GUILayout.Toggle(false, "Mono"))
            ascensor.CambiarTagSubir("Mono");
        if (GUILayout.Toggle(false, "Todos"))
            ascensor.CambiarTagSubir("Todos");
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        GUILayout.Space(5);
        GUILayout.Label("Tag de bajada");
        if (GUILayout.Toggle(false, "Tripulante"))
            ascensor.CambiarTagInferior("Tripulante");
        if (GUILayout.Toggle(false, "Doctor"))
            ascensor.CambiarTagInferior("Doctor");
        if (GUILayout.Toggle(false, "TripulanteAlien"))
            ascensor.CambiarTagInferior("TripulanteAlien");
        if (GUILayout.Toggle(false, "TripulanteIngeniera"))
            ascensor.CambiarTagInferior("TripulanteIngeniera");
        if (GUILayout.Toggle(false, "Mono"))
            ascensor.CambiarTagInferior("Mono");
        if (GUILayout.Toggle(false, "Todos"))
            ascensor.CambiarTagInferior("Todos");
        GUILayout.EndVertical();
    }
}
