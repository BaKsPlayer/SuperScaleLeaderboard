using UnityEngine;

namespace SC.UI.View
{
    public class BaseScreen : MonoBehaviour
    {
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}