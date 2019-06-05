using UnityEngine;
using UnityEngine.UI;

namespace Template
{
	public class GameController : SceneController
	{

		[SerializeField]
		private Button NextButton;

		[SerializeField]
		private Button BackButton;

		public override void Navigation()
		{
			Back = BackButton;
			//AddNavigation(NextButton, SceneNavigation.NextScene);
			//AddNavigation(Back, SceneNavigation.PreviousScene);
		}

		public string NextScene()
		{
			return SceneNavigation.NextScene;
		}

		public string BackScene()
		{
			return SceneNavigation.PreviousScene;
		}

		public new void AddNavigation(Button button, string scene, bool async = false, System.Action action = null)
		{
			base.AddNavigation(button, scene, async, action);
		}
	}
}

