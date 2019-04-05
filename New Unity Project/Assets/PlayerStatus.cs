using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    public int Hp;
    public Text Batterytext;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
            Batterytext.text = "Hp：" + Hp;
    }
    public int GetHp()
    {
        return Hp;
    }
    public void Damage(int damege)
    {
        Hp -= damege;
    }
    public void HpRecovery(int Recovery)
    {
        Hp += Recovery;
    }
    private void OnTriggerEnter(Collider other)
    {
  

    }
}
