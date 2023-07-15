using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private List<GameObject> bloonsInRange;

    [SerializeField] float attackSpeed = 1f;
    private float nextAttackTime = 0f;

    public GameObject bulletType;

    // Start is called before the first frame update
    void Start()
    {
        bloonsInRange = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAttackTime) {
            GameObject targettedBloon = targetBloon();
            if (targettedBloon) {
                GameObject bullet = Instantiate(bulletType, transform.position, Quaternion.Euler(0.0f, 0.0f, 90.0f));
                bullet.GetComponent<BasicBulletController>().SetTarget(targettedBloon);
                Debug.Log("Attack!" + targettedBloon.GetComponent<BloonController>().id);
                nextAttackTime = Time.time + (1f / attackSpeed);
                Debug.Log(Time.time + " " + nextAttackTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "bloon"){
            bloonsInRange.Add(other.gameObject);
            BloonController bc = other.gameObject.GetComponent<BloonController>();
            bc.OnDeath += OnBloonDeath;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "bloon"){
            bloonsInRange.Remove(other.gameObject);
            BloonController bc = other.gameObject.GetComponent<BloonController>();
            bc.OnDeath -= OnBloonDeath;
        }
    }

    private GameObject targetBloon() {
        if (bloonsInRange.Count == 0) {
            return null;
        } else {
            GameObject closestBloon = null;
            float closestDist = float.MaxValue;
            foreach (GameObject b in bloonsInRange) {
                BloonController bc = b.GetComponent<BloonController>();
                if (closestDist > bc.GetDistToEnd()) {
                    closestBloon = b;
                    closestDist = bc.GetDistToEnd();
                }
            }
            return closestBloon;
        }
    }

    private void OnBloonDeath(object sender, EventArgs e) {
        BloonController bc = (BloonController) sender;
        bool success = bloonsInRange.Remove(bc.gameObject);
        if (!success) Debug.Log("Tower: failed to remove bloon from list");
    }
}
