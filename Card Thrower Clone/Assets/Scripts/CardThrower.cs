using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardThrower : MonoBehaviour
{
    public GameManager gameManager;
    public Transform desPos;
    public GameObject cardPrefab;
    public GameObject cardParent;


    private void Update()
    {
        ThrowCard();
        SpreadShot();
        DualShot();
    }

    public void ThrowCard()
    {
        if (gameManager.gameStart && !gameManager.canDualShot && !gameManager.canSpreadShot)
        {
            gameManager.cardCoolDown -= Time.deltaTime;
            if (gameManager.cardCoolDown <= 0)
            {
                gameManager.cardCoolDown = gameManager.temporaryThrowRate;
                GameObject go = Instantiate(cardPrefab, desPos.position, transform.rotation, cardParent.transform);
                go.GetComponent<Rigidbody>().velocity = transform.forward * 5;
                go.LeanRotateAroundLocal(transform.up, 1500f * gameManager.temporaryCardRange, 1f * gameManager.temporaryCardRange).setEase(LeanTweenType.clamp);
                Destroy(go, gameManager.temporaryCardRange);
            }
        }
    }

    public void SpreadShot()
    {
        if (gameManager.canSpreadShot)
        {
            gameManager.cardCoolDown -= Time.deltaTime;
            if (gameManager.cardCoolDown <= 0)
            {
                gameManager.cardCoolDown = gameManager.temporaryThrowRate;
                GameObject go1 = Instantiate(cardPrefab, desPos.position - new Vector3(-0.1f, 0, 0), transform.rotation, cardParent.transform);
                GameObject go2 = Instantiate(cardPrefab, desPos.position, transform.rotation, cardParent.transform);
                GameObject go3 = Instantiate(cardPrefab, desPos.position - new Vector3(0.1f, 0, 0), transform.rotation, cardParent.transform);
                go1.GetComponent<Rigidbody>().velocity = transform.forward * 5 + (-transform.right * 1.05f);
                go2.GetComponent<Rigidbody>().velocity = transform.forward * 5;
                go3.GetComponent<Rigidbody>().velocity = transform.forward * 5 + (transform.right * 1.05f);
                go1.LeanRotateAroundLocal(transform.up, 1500f * gameManager.temporaryCardRange, 1f * gameManager.temporaryCardRange).setEase(LeanTweenType.clamp);
                go2.LeanRotateAroundLocal(transform.up, 1500f * gameManager.temporaryCardRange, 1f * gameManager.temporaryCardRange).setEase(LeanTweenType.clamp);
                go3.LeanRotateAroundLocal(transform.up, 1500f * gameManager.temporaryCardRange, 1f * gameManager.temporaryCardRange).setEase(LeanTweenType.clamp);
                Destroy(go1, gameManager.temporaryCardRange);
                Destroy(go2, gameManager.temporaryCardRange);
                Destroy(go3, gameManager.temporaryCardRange);
            }

        }
    }

    public void DualShot()
    {
        if (gameManager.canDualShot)
        {
            gameManager.cardCoolDown -= Time.deltaTime;
            if (gameManager.cardCoolDown <= 0)
            {
                gameManager.cardCoolDown = gameManager.temporaryThrowRate;
                GameObject go1 = Instantiate(cardPrefab, desPos.position - new Vector3(-0.1f, 0, 0), transform.rotation, cardParent.transform);
                GameObject go2 = Instantiate(cardPrefab, desPos.position - new Vector3(0.1f, 0, 0), transform.rotation, cardParent.transform);
                go1.GetComponent<Rigidbody>().velocity = transform.forward * 5;
                go2.GetComponent<Rigidbody>().velocity = transform.forward * 5;
                go1.LeanRotateAroundLocal(transform.up, 1500f * gameManager.temporaryCardRange, 1f * gameManager.temporaryCardRange).setEase(LeanTweenType.clamp);
                go2.LeanRotateAroundLocal(transform.up, 1500f * gameManager.temporaryCardRange, 1f * gameManager.temporaryCardRange).setEase(LeanTweenType.clamp);
                Destroy(go1, gameManager.temporaryCardRange);
                Destroy(go2, gameManager.temporaryCardRange);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ThrowRate":
                GatePassiveColor(other.gameObject);
                EventManager.BroadCast(GameEvent.OnThrowRate);
                Debug.Log("Throw Rate");
                break;
            case "CardRange":
                GatePassiveColor(other.gameObject);
                EventManager.BroadCast(GameEvent.OnCardRange);
                Debug.Log("Card Range");
                break;
            case "SpreadShot":
                GatePassiveColor(other.gameObject);
                EventManager.BroadCast(GameEvent.OnSpreadShot);
                Debug.Log("Spread Shot");
                break;
            case "DualShot":
                GatePassiveColor(other.gameObject);
                EventManager.BroadCast(GameEvent.OnDualShot);
                Debug.Log("Dual Shot");
                break;
        }
    }

    void GatePassiveColor(GameObject other)
    {
        other.transform.GetComponent<MeshRenderer>().materials[2].color = Color.grey;
    }

}
