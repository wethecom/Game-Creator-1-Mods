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
      

        public TargetGameObject ParentTarget = new TargetGameObject();
        // public ActionType actionType = ActionType.Attach;

        public TargetGameObject ChildTarget = new TargetGameObject();
       // public float AttachMinRadius = 2.0f;
       // public float AttachMaxRadius = 4.0f;

        // EXECUTABLE: ----------------------------------------------------------------------------

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            Transform ParTarget = null;
            ParTarget = this.ParentTarget.gameObject.transform;
            Transform ChildTarget = null;
            ChildTarget = this.ChildTarget.GetComponent<Transform>(target);

            ChildTarget.transform.parent = ParTarget.transform;

            // charTarget.characterLocomotion.AttachTarget(
            //     Attach,
            //     this.AttachMinRadius,
            //    this.AttachMaxRadius
            // );

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
