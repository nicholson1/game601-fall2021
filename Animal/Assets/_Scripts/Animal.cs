using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Start is called before the first frame update
    public Animaltype type;
    public enum Animaltype
    {
        Ibex,
        Bear,
        Chicken,
        Wolf,
        Cow
    }
}
