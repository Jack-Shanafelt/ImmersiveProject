using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScriptAction
{
    public MonoBehaviour script;
    public UnityEvent action;
}
public class NewButton : MonoBehaviour
{
 public float deadTime = 1.0f;
    private bool _deadTimeActive = false;
    public UnityEvent onPressed, onReleased;
    public string[] triggerTags = { "Body", "Part" }; // tags to trigger onPressed and onReleased
    public List<ScriptAction> scriptActions; // scripts and actions to activate on Part objects
    public Collider triggerArea; // the trigger area

    private void OnTriggerEnter(Collider other)
    {
        if (other == triggerArea && IsTriggerTag(other.tag) && !_deadTimeActive)
        {
            onPressed.Invoke();
            if (other.tag == "Part")
            {
                foreach (var scriptAction in scriptActions)
                {
                    scriptAction.script.enabled = true; // activate the script
                    scriptAction.action.Invoke(); // call the action
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == triggerArea && IsTriggerTag(other.tag) && !_deadTimeActive)
        {
            onReleased.Invoke();
            if (other.tag == "Part")
            {
                foreach (var scriptAction in scriptActions)
                {
                    scriptAction.script.enabled = false; // deactivate the script
                }
            }
            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActive = false;
    }

    private bool IsTriggerTag(string tag)
    {
        foreach (string triggerTag in triggerTags)
        {
            if (tag == triggerTag)
            {
                return true;
            }
        }
        return false;
    }
}