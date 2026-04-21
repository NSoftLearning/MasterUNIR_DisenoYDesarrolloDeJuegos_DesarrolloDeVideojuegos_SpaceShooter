public struct PlayerStatusData
{
    public float afterHitInvulnerabilityTime;
    public int maxHealth;
    public int remainingHealth;

    public PlayerStatusData (float afterHitInvulnerabilityTime, int maxHealth, int remainingHealth)
    {
        this.maxHealth = maxHealth;
        this.remainingHealth = remainingHealth;
        this.afterHitInvulnerabilityTime = afterHitInvulnerabilityTime;
    }
}
