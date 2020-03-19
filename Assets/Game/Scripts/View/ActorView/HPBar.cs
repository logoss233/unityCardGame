using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    public Image HpImg;
    public Text hpText;
    public GameObject shieldGo;
    public Text shieldText;
    public int _maxHp;
    public int _hp;
    public int _shield;
    public int maxHp
    {
        get { return this._maxHp; }
        set { this._maxHp = value;this.updateHpBar();}
    }
    public int hp
    {
        get { return this._hp; }
        set { this._hp = value;this.updateHpBar(); }
    }
    public int shield
    {
        get { return this._shield; }
        set
        {
            this._shield = value;
            this.updateShield();
        }
    }


    private Material material;
    public void init(int hp,int maxHp,int shield)
    {
        this.HpImg.material = Instantiate(this.HpImg.material);
        this.material = this.HpImg.material;
        this._hp = hp;
        this._maxHp = maxHp;
        this._shield = shield;
        this.updateHpBar();
        this.updateShield();
    }

    private void updateHpBar()
    {
        float n = (float)this.hp / this.maxHp;
        this.material.SetFloat("_ClipUvRight", 1 - n);
        this.hpText.text = this.hp.ToString() + "/" + this.maxHp.ToString();
    }
    private void updateShield()
    {
        if (this.shield > 0)
        {
            this.shieldGo.SetActive(true);
            this.shieldText.text = this.shield.ToString();
        }
        else
        {
            this.shieldGo.SetActive(false);
        }
    }
}
