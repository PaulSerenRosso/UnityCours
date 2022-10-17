
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GraphFeeder :MonoBehaviour
    {
        [SerializeField] private UIGraphRenderer uiGraphRenderer;
        [SerializeField] private float interval = 0.25f;

        [SerializeField] private float maxValue = 100;
        [SerializeField] private float minValue = 50; 
        private void Start()
        {
            StartCoroutine(FeedLoop());
        }

        IEnumerator FeedLoop()
        {
            yield return new WaitForSeconds(interval);
            uiGraphRenderer.AddPoint(Random.Range(minValue,maxValue));
            StartCoroutine(FeedLoop());
            uiGraphRenderer.SetVerticesDirty();
        }
    }