using UnityEngine;
using System.Collections;

namespace Template
{
	public class SceneNavigation : MonoBehaviour, ISceneNavigation
	{
		[SerializeField]
		private string nextScene;
		[SerializeField]
		private string previousScene;

		public const string Exit = "Exit";

		public string NextScene
		{
			get
			{
				return nextScene;
			}
		}

		public string PreviousScene
		{
			get
			{
				return previousScene;
			}
		}

	}
}

