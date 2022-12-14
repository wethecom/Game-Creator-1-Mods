namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using GameCreator.Core;

	#if UNITY_EDITOR
	using UnityEditor;
	#endif

	[AddComponentMenu("")]
	public class UnParent : IAction
	{

        public TargetGameObject Target = new TargetGameObject();
        // public ActionType actionType = ActionType.Attach;

        // EXECUTABLE: ----------------------------------------------------------------------------

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            Transform ParTarget = null;
            ParTarget = this.Target.gameObject.transform;

            ParTarget.transform.parent = null;
           


            return true;
        }



        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+

        #if UNITY_EDITOR

        public static new string NAME = "Custom/UnParent";
		private const string NODE_TITLE = "Example value is {0}";

        private SerializedProperty spTarget;
        // private SerializedProperty spActionType;

      //  private SerializedProperty spChildTarget;
        // private SerializedProperty spMinRadius;
        //private SerializedProperty spMaxRadius;

        // INSPECTOR METHODS: ---------------------------------------------------------------------

        public override string GetNodeTitle()
        {
            return string.Format(
                NODE_TITLE,
                this.Target,
                ObjectNames.NicifyVariableName("Unparent")
            );
        }

        protected override void OnEnableEditorChild()
        {
            this.spTarget = this.serializedObject.FindProperty("ParentTarget");
            //this.spActionType = this.serializedObject.FindProperty("actionType");
         //   this.spChildTarget = this.serializedObject.FindProperty("ChildTarget");
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

            EditorGUILayout.PropertyField(this.spTarget);
            //EditorGUILayout.PropertyField(this.spActionType);


  //          EditorGUILayout.Space();
  //          EditorGUILayout.PropertyField(this.spChildTarget);

            //  EditorGUILayout.PropertyField(this.spMinRadius);
            //  EditorGUILayout.PropertyField(this.spMaxRadius);


            this.serializedObject.ApplyModifiedProperties();
        }

#endif
    }
}
