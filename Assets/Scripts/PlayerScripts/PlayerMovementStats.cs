using UnityEngine;

[CreateAssetMenu(menuName ="Player Movement")]
public class PlayerMovementStats : ScriptableObject
{
    [Header("Move")]
    [Range(1f, 100f)] public float maxMoveSpeed = 25f;
    [Range(0.25f, 50)] public float GroundAccelaration = 5f;
    [Range(0.25f, 50)] public float GroundDeceleration = 20f;
    [Range(0.25f, 50)] public float AirAccelaration = 5f;
    [Range(0.25f, 50)] public float AirDecelaration = 5f;

    [Header("Ground/Collision Checks")]
    public LayerMask GroundLayer;
    public float GroundCheckRadius = 0.02f;
    public float HeadDetectionRayLength = 0.02f;
    [Range(0f, 1f)] public float HeadWidth = 0.75f;
}
