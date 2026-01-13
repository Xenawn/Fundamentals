using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirebaseController : MonoBehaviour
{
    public GameObject loginPanel, signupPanel, profilePanel, forgetPasswordPanel, notificationPanel;
    public TMP_InputField loginEmail, loginPassword, signupEmail, signupPassword, signupCPassword, signupUserName,forgetPassEmail;
    public TextMeshProUGUI notif_Title_text, notif_msg_txt,profile_UserName_Text,profile_Email_Text;
    public Toggle rememberme;
    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
    }

    public void OpenSignUpPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
    }
    public void OpenProfilePanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
    }
    public void OpenForgetPassPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(true);
    }

    public void LoginUser()
    {
        if(string.IsNullOrEmpty(loginEmail.text) && string.IsNullOrEmpty(loginPassword.text))
        {
            showNotificationMessage("Error", "Fields Empty! Please Input Details In All Fields");
            return;
        }

        //Do Login
    }

    public void SignUpUser()
    {
        if(string.IsNullOrEmpty(signupEmail.text) && string.IsNullOrEmpty(signupPassword.text) && string.IsNullOrEmpty(signupCPassword.text) && string.IsNullOrEmpty(signupUserName.text))
        {
            showNotificationMessage("Error", "Fields Empty! Please Input Details In All Fields");
            return;
        }

        // Do signUp
    }

    public void forgetPass()
    {
        if (string.IsNullOrEmpty(forgetPassEmail.text) )
        {
            showNotificationMessage("Error", "Fields Empty! Please Input Details In All Fields");
            return;
        }
    }

    private void showNotificationMessage(string title, string message)
    {
        notif_Title_text.text = "" + title;
        notif_msg_txt.text = "" + message;

        notificationPanel.SetActive(true);
    }

    public void CloseNotif_Panel()
    {
        notif_Title_text.text = "";
        notif_msg_txt.text = "";
        notificationPanel.SetActive(false);
    }

    public void LogOut()
    {
        profilePanel.SetActive(false);
        profile_UserName_Text.text = "";
        profile_Email_Text.text = "";
        OpenLoginPanel();
    }
}
