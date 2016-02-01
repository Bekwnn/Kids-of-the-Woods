using UnityEngine;
using System.Collections.Generic;
using System.Linq.Expressions;

public class KBinding
{
	public delegate void Execute();
	public delegate bool BoolExpr();

	public Execute e;
	public BoolExpr b;

	public KBinding(BoolExpr bExpr, Execute exec)
	{
		e = exec;
		b = bExpr;
	}
}

public class KPlayerController : MonoBehaviour
{
	public List<KBinding> bindings;

	void Awake()
	{
		bindings = new List<KBinding>();
		//AddBinding( () => { return Input.GetKeyDown(KeyCode.Space); }, Test);
	}

	public void Test()
	{
		Debug.Log("Hello!");
	}

	void Update()
	{
		foreach (KBinding binding in bindings)
		{
			if (binding.b()) binding.e();
		}
	}

	public void AddBinding(KBinding.BoolExpr boolExpression, KBinding.Execute execute)
	{
		bindings.Add(new KBinding(boolExpression, execute));
	}
}
