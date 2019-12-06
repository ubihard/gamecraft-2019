using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public GameObject attack;
    public GameObject defense;
    public GameObject magic;
    public GameObject potion;

    private GameObject[] notes;
    public float startX;
    public int numBeats;

    // Start is called before the first frame update
    void Start()
    {
        notes = new GameObject[]{ attack, defense, magic, potion };
        generateNoteMap();
    }

    private GameObject generateBeat(int index, float xTranslate)
    {
        GameObject beat = Instantiate(notes[index], transform) as GameObject;
        beat.transform.position = new Vector3(startX + xTranslate, notes[index].transform.localPosition.y, 0);
        return beat;
    }

    private void generateDecisionBeat(float xTranslate)
    {
        GameObject special = new GameObject();
        special.tag = "Special";
        special.transform.parent = transform;
        generateBeat(0, xTranslate).transform.parent = special.transform;
        generateBeat(1, xTranslate).transform.parent = special.transform;
        generateBeat(2, xTranslate).transform.parent = special.transform;
        generateBeat(3, xTranslate).transform.parent = special.transform;
    }

    void generateNoteMap() {
        System.Random rnd = new System.Random();
        float currX = 0;
        for (int i = 0; i < numBeats / 20; i++)
        {
            int[] ratios = { 6, 6, 2, 2, 4 };
            List<int> indexList = new List<int> { 0, 1, 2, 3, 4 };
            int end = indexList.Count;
            if (i % 6 == 0)
            {
                generateDecisionBeat(currX);
                currX++;
                ratios[1]--;
            }
            while (end > 0)
            {
                int index = rnd.Next(0, end);
                if (indexList[index] != 4)
                {
                    generateBeat(indexList[index], currX);
                }

                currX++;
                ratios[indexList[index]]--;
                if (ratios[indexList[index]] == 0)
                {
                    indexList.RemoveAt(index);
                    end--;
                }
            }
        }
    }
}
