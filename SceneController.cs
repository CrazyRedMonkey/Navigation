using UnityEngine;
using UnityEngine.UI;

namespace Template
{
	public abstract class SceneController : DefaultStartSettings, IController
	{
		private ISceneNavigation sceneNavigation;

		protected ISceneNavigation SceneNavigation
		{
			get
			{
				if (sceneNavigation == null)
				{
					var component = Object.FindObjectsOfType(typeof(SceneNavigation)) as SceneNavigation[];
					if (component == null || component.Length < 1)
					{
						Utils.PrintErrorMessage("На сцене нет объекта со скриптом SceneNavigation");
						throw new System.NullReferenceException("sceneNavigation");
					}
					if (component.Length > 1)
					{
						Utils.PrintErrorMessage("На сцене более одного объекта со скриптом SceneNavigation");
					}
					sceneNavigation = component[0];
				}
				return sceneNavigation;
			}

			set
			{
				sceneNavigation = value;
			}
		}

		protected Button Back;

		protected new void Awake()
		{
			base.Awake();
			if (Back == null)
			{
				var go = new GameObject("BackButton", typeof(Button));
				Back = go.GetComponent<Button>();
			}
			Navigation();

		}

		public abstract void Navigation();

		protected void Update()
		{
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				if (DefaultPanel.OpenPanelCount() > 0)
				{
					DefaultPanel.CloseLastPanel();
				}
				else
				{
					Back.onClick.Invoke();
				}
			}
		}
	}
}
