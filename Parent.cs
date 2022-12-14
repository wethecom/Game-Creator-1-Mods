namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using GameCreator.Core;

	#if UNITY_EDITOR
	using UnityEditor;
    using GameCreator.Characters;
#endif

    [AddComponentMenu("")]
	public class Parent : IAction
	{
       // Public fields that can be set in the inspector:
    public TargetGameObject ParentTarget = new TargetGameObject(); // Game object to parent the child to
    public TargetGameObject ChildTarget = new TargetGameObject(); // Game object to be parented

    // Method that is called when the action is executed:
    public override bool InstantExecute(GameObject target, IAction[] actions, int index)
    {
        // Get the transform of the parent game object:
        Transform ParTarget = null;
        ParTarget = this.ParentTarget.gameObject.transform;

        // Get the transform of the child game object:
        Transform ChildTarget = null;
        ChildTarget = this.ChildTarget.GetComponent<Transform>(target);

        // Set the transform parent of the child game object to the transform of the parent game object:
        ChildTarget.transform.parent = ParTarget.transform;

        // Set the local position and rotation of the child game object to zero:
        ChildTarget.transform.localPosition = Vector3.zero;
        ChildTarget.transform.localEulerAngles = Vector3.zero;

        // Return true to indicate that the action was successful:
        return true;
    }



        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+

#if UNITY_EDITOR

        public static new string NAME = "Custom/Parent";
		private const string NODE_TITLE = "Parent/Child";

        // PROPERTIES: ----------------------------------------------------------------------------

        private SerializedProperty spParentTarget;
       // private SerializedProperty spActionType;

        private SerializedProperty spChildTarget;
       // private SerializedProperty spMinRadius;
        //private SerializedProperty spMaxRadius;

        // INSPECTOR METHODS: ---------------------------------------------------------------------

        public override string GetNodeTitle()
        {
            return string.Format(
                NODE_TITLE,
                this.ParentTarget,
                ObjectNames.NicifyVariableName(this.ChildTarget.ToString()+ " Attach to" +this.ParentTarget.ToString() )
            );
        }

        protected override void OnEnableEditorChild()
        {
            this.spParentTarget = this.serializedObject.FindProperty("ParentTarget");
            //this.spActionType = this.serializedObject.FindProperty("actionType");
            this.spChildTarget = this.serializedObject.FindProperty("ChildTarget");
           // this.spMinRadius = this.serializedObject.FindProperty("AttachMinRadius");
          //  this.spMaxRadius = this.serializedObject.FindProperty("AttachMaxRadius");
        }

        protected override void OnDisableEditorChild()
        {
            return;
        }

        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            EditorGUILayout.PropertyField(this.spParentTarget);
            //EditorGUILayout.PropertyField(this.spActionType);

            
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(this.spChildTarget);

              //  EditorGUILayout.PropertyField(this.spMinRadius);
              //  EditorGUILayout.PropertyField(this.spMaxRadius);


            this.serializedObject.ApplyModifiedProperties();
        }

#endif
    }
}
