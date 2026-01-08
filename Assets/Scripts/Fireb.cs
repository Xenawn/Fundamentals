using Firebase;
using Firebase.Auth;
using UnityEngine;

public class Fireb : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            if (task.Result == DependencyStatus.Available)
            {
                Debug.Log(" Firebase 초기화 성공!");
                FirebaseAuth auth = FirebaseAuth.DefaultInstance;
                Debug.Log(" Firebase Auth 사용 가능!");
            }
            else
            {
                Debug.LogError($" Firebase 초기화 실패: {task.Result}");
            }
        });
    }
}
