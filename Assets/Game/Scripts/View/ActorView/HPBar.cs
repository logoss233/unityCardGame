using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    public Image HpImg;
    public Text text;
    public int _maxHp;
    public int _hp;
    public int maxHp
    {
        get { return this._maxHp; }
        set { this._maxHp = value;this.updateBar();}
    }
    public int hp
    {
        get { return this._hp; }
        set { this._hp = value;this.updateBar(); }
    }

    private Material material;
    public void init(int hp,int maxHp)
    {
        this.HpImg.material = Instantiate(this.HpImg.material);
        this.material = this.HpImg.material;
        this._hp = hp;
        this._maxHp = maxHp;
        this.updateBar();
    }

    private void updateBar()
    {
        float n = (float)this.hp / this.maxHp;
        this.material.SetFloat("_ClipUvRight", 1 - n);
        this.text.text = this.hp.ToString() + "/" + this.maxHp.ToString();
    }
}
