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

    private void generateBeat(int index, float xTranslate)
    {
        GameObject beat = Instantiate(notes[index], this.transform) as GameObject;
        beat.transform.position = new Vector3(startX + xTranslate, notes[index].transform.localPosition.y, 0);
    }

    void generateNoteMap() {
        System.Random rnd = new System.Random();
        float currX = 0;
        for (int i = 0; i < numBeats / 20; i++)
        {
            int[] ratios = { 8, 6, 2, 2, 2 };
            List<int> indexList = new List<int> { 0, 1, 2, 3, 4 };
            int end = indexList.Count;
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
