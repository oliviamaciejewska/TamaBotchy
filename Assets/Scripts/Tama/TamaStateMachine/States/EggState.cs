using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggState : TamaBaseState
{
    float eggHatchCountdown = 5.0f;

    public EggState(TamaStateMachine stateMachine) : base("Egg", stateMachine) { }

    public override void Enter()
    {
        stateMachine.animator.Play("egg");
        stateMachine.ChangeSprite(0);
        //StartCoroutine("Hatch");
    }

    public override void Update()
    {
        if (eggHatchCountdown >= 0)
        {
            eggHatchCountdown -= Time.deltaTime;
        }
        else
        {
            stateMachine.ChangeState(stateMachine.adultState);
        }
    }

    public override void UpdatePhysics()
    {
    }

    public override void Exit()
    {
        stateMachine.eggHatch.Play();
        stateMachine.tamaGenerator.MakeTama();
    }

    //IEnumerator Hatch()
    //{
    //    yield return new WaitForSecondsRealtime(5);
    //    Destroy(this.gameObject);
    //    GameObject tama = Instantiate(tamaPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    //    tamaGenerator.MakeTama(tama);
    //}
}
