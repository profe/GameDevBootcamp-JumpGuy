using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic, _playerSFX, _blockSFX, _enemySFX, _collectibleSFX;
    [SerializeField] private AudioClip _clipJump, _clipRespawn, _clipCollectible, _clipBlockBreak, _clipGameOver;

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "jump":
                _playerSFX.PlayOneShot(_clipJump);
                break;
            case "respawn":
                _playerSFX.PlayOneShot(_clipRespawn);
                break;
            case "collectible":
                _collectibleSFX.PlayOneShot(_clipCollectible);
                break;
            case "break_block":
                _blockSFX.PlayOneShot(_clipBlockBreak);
                break;
            case "game_over":
                _backgroundMusic.Stop();
                _backgroundMusic.PlayOneShot(_clipGameOver);
                break;
        }
    }
}
