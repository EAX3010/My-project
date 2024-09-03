using Assets.Interface;
using Assets.Scripts.Interface;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField]
    public KitchenScriptableObjects itemSelected;

    [SerializeField]
    [Tooltip("Movement speed of the player")]
    private float movementSpeed = 8f;

    [SerializeField]
    [Tooltip("LayerMask for Interactable Objects")]
    private LayerMask interactionLayerMask;
    [SerializeField]
    private Transform spawnPoint;

    private bool isMoving;
    private Vector3 lookingAt;
    private GameInput gameInput;
    private IInteractableObject selectedCounter;
    private KitchenObject kitchenObject;
    private const float InteractionDistance = 1f;
    private const float PlayerHeight = 2f;
    private const float PlayerRadius = 0.7f;
   

    void Start()
    {
        // Initialize GameInput and subscribe to events
        gameInput = new GameInput();
        gameInput.OnInteractAction += OnInteractAction;
        transform.FaceObjectToCamera();
    }
    void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    private void OnInteractAction(object sender, EventArgs e)
    {
        selectedCounter?.Interact(this);
    }

    private void HandleInteractions()
    {
        Vector3 movementDir = gameInput.GetPlayerMovementNormalized();
        if (movementDir != Vector3.zero)
        {
            lookingAt = movementDir;
        }

        if (Physics.Raycast(transform.position, lookingAt, out RaycastHit hit, InteractionDistance, interactionLayerMask))
        {
            if (hit.transform.TryGetComponent(out IInteractableObject interactableObject))
            {
                UpdateSelectedCounter(interactableObject);
            }
            else
            {
                ClearSelectedCounter();
            }
        }
        else
        {
            ClearSelectedCounter();
        }
    }

    private void UpdateSelectedCounter(IInteractableObject newCounter)
    {
        if (selectedCounter != newCounter)
        {
            selectedCounter?.HoverOff(this);
            selectedCounter = newCounter;
            selectedCounter?.HoverOn(this);
        }
    }

    private void ClearSelectedCounter()
    {
        if (selectedCounter != null)
        {
            selectedCounter.HoverOff(this);
            selectedCounter = null;
        }
    }

    private void HandleMovement()
    {
        Vector3 movementDir = gameInput.GetPlayerMovementNormalized();
        float moveDistance = movementSpeed * Time.deltaTime;
        float rotationSpeed = (movementSpeed * 1.4f) * Time.deltaTime;

        if (CanMove(movementDir, moveDistance))
        {
            transform.position += movementDir * moveDistance;
            transform.forward = Vector3.Slerp(transform.forward, movementDir, rotationSpeed);
            isMoving = movementDir != Vector3.zero;
        }
        else
        {
            AdjustMovementDirection(ref movementDir, moveDistance);
        }
    }

    private bool CanMove(Vector3 direction, float distance)
    {
        return !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PlayerHeight, PlayerRadius, direction, distance);
    }

    private void AdjustMovementDirection(ref Vector3 movementDir, float moveDistance)
    {
        Vector3 newDir = Vector3.zero;
        if (!CanMove(movementDir, moveDistance))
        {
            newDir = new Vector3(movementDir.x, 0, 0).normalized;
            if (!CanMove(newDir, moveDistance))
            {
                newDir = new Vector3(0, 0, movementDir.z).normalized;
                if (!CanMove(newDir, moveDistance))
                {
                    return; // Cannot move in any direction
                }
            }
        }
        movementDir = newDir;
        transform.position += movementDir * moveDistance;
        transform.forward = Vector3.Slerp(transform.forward, movementDir, movementSpeed * 1.4f * Time.deltaTime);
        isMoving = movementDir != Vector3.zero;
    }

    public bool IsMoving()
    {
        return isMoving;
    }
    public KitchenObject GetKitchenObject()
    {
        return this.kitchenObject;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }
}
