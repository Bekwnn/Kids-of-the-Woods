using UnityEngine;
using System.Collections.Generic;
using System.Linq.Expressions;

public enum EBindType
{
	GET,
	GETDOWN,
	GETUP
}

public class KBinding
{
	public delegate void Execute();
	public delegate bool BoolExpr();


	public KeyCode keyCode;
	public string button;
	protected bool bButton; // true if uses button, false if uses keyCode

	public Execute exec;
	public BoolExpr bexpr;

	public KBinding(KeyCode k, EBindType bindType, Execute e)
	{
		exec = e;
		bButton = false;
		this.keyCode = k;
		
		switch (bindType)
		{
			case EBindType.GET:
				bexpr = () => { return Input.GetButton(button); };
				break;
			case EBindType.GETDOWN:
				bexpr = () => { return Input.GetButtonDown(button); };
				break;
			case EBindType.GETUP:
				bexpr = () => { return Input.GetButtonUp(button); };
				break;
			default:
				break;
		}
	}

	public KBinding(string button, EBindType bindType, Execute e)
	{
		exec = e;
		bButton = true;
		this.button = button;
		
		switch (bindType)
		{
			case EBindType.GET:
				bexpr = () => { return Input.GetButton(button); };
				break;
			case EBindType.GETDOWN:
				bexpr = () => { return Input.GetButtonDown(button); };
				break;
			case EBindType.GETUP:
				bexpr = () => { return Input.GetButtonUp(button); };
				break;
			default:
				break;
		}
	}
}

public class KPlayerController : MonoBehaviour
{
	public List<KBinding> bindings;

	void Awake()
	{
		bindings = new List<KBinding>();
		AddBinding("Jump", EBindType.GETDOWN, TestDown);
		AddBinding(KeyCode.Space, EBindType.GETUP, TestUp);
	}

	public void TestDown()
	{
		Debug.Log("Down!");
	}
	public void TestUp()
	{
		Debug.Log("Up!");
	}

	void Update()
	{
		foreach (KBinding binding in bindings)
		{
			if (binding.bexpr()) binding.exec();
		}
	}

	public void AddBinding(string button, EBindType bindType, KBinding.Execute execute)
	{
		bindings.Add(new KBinding(button, bindType, execute));
	}

	public void AddBinding(KeyCode key, EBindType bindType, KBinding.Execute execute)
	{
		bindings.Add(new KBinding(key, bindType, execute));
	}
}
