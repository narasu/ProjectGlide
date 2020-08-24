using UnityEngine;
using UnityEditor;
using PathCreation;

[ExecuteInEditMode]
[CustomEditor(typeof(Follower))]
public class FollowerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Follower follower = (Follower)target;

        follower.pathCreator = (PathCreator)EditorGUILayout.ObjectField("Path Creator:",follower.pathCreator,typeof(PathCreator),true);
        follower.startingPoint = EditorGUILayout.Slider("Starting point on path: ",follower.startingPoint, 0, follower.pathCreator.path.length);
        follower.endOfPathInstruction = (EndOfPathInstruction)EditorGUILayout.EnumPopup("End of path instruction:", follower.endOfPathInstruction);

        if (!Application.isPlaying)
        {
            follower.distanceTravelled = follower.startingPoint;
            follower.SetPositionAlongPath();
        }
    }
}
