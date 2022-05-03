using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace GenLibrary
{
    public class ExtendedScrollRect : ScrollRect
    {
        public event Action<PointerEventData> NewOnBeginDrag;
        public event Action<PointerEventData> NewOnEndDrag;

        [SerializeField]
        public Vector2 last_OnScroll_pos;

        public override void OnScroll(PointerEventData data)
        {
            base.OnScroll(data);
            last_OnScroll_pos = data.position;
            Debug.Log("NewScrollRect last_OnScroll_pos = " + last_OnScroll_pos);
            //this.Scroll
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            NewOnBeginDrag?.Invoke(eventData);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            NewOnEndDrag?.Invoke(eventData);
        }


    }
}