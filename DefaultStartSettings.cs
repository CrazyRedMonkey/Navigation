using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Template
{
	public class DefaultStartSettings : MonoBehaviour
	{
		protected void Awake()
		{
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}

		private void SimpleTransition(Button button, string sceneName, System.Action action = null)
		{
			button.onClick.AddListener(() =>
			{
				if (action != null)
				{
					action.Invoke();
				}
				SceneManager.LoadScene(sceneName);
			});
		}

		protected void AddNavigation(Button button, string sceneName, bool async = false, System.Action action = null)
		{
			if (sceneName == SceneNavigation.Exit)
			{
				button.onClick.AddListener(() =>
				{
					Utils.PrintErrorMessage("Application.Quit");
					Application.Quit();
				});
			}
			else
			{
				if (!async)
				{
					SimpleTransition(button, sceneName, action);
				}
				else
				{
					var dummyscript = FindObjectOfType(typeof(Dummy)) as Dummy;
					if (dummyscript == null)
					{
						Utils.PrintErrorMessage("На сцене нет объякта со скриптом Dummy. Осуществлен обычный переход");
						SimpleTransition(button, sceneName, action);
					}
					else
					{
						button.onClick.AddListener(() => { dummyscript.LoadSceneAsycn(sceneName, action);});
					}

				}
			}
		}

		protected void AddNavigation(Button button, UnityEngine.Events.UnityAction navigation)
		{
			button.onClick.AddListener(navigation);
		}

			
	}
}
