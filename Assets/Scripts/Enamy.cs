using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Collider))]
public class Enamy : MonoBehaviour
{
    [SerializeField] private Material inactiveMaterial;
    [SerializeField] private Material gazedAtMaterial;
    [SerializeField] private Renderer myRenderer;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Player player;
    [SerializeField] private float timeBetweenAttacks = 0.5f;

    private int attackDamage = 20;
    private float distance = 14f;
    private float timer;

    private void Update()
    {
        nav.SetDestination(player.transform.position);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks)
            {
                Attack();
            }
        }
    }

    /// <summary>Attack player.</summary>
    private void Attack()
    {
        timer = 0f;
        player.GetDamage(attackDamage);
    }

    /// <summary>Sets this instance's GazedAt state.</summary>
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }

    /// <summary>Teleport this instance randomly when triggered by a pointer click.</summary>
    /// <param name="eventData">The pointer click event which triggered this call.</param>
    public void TeleportRandomly(BaseEventData eventData)
    {
        gameObject.SetActive(false);

        // Only trigger on left input button, which maps to
        // Daydream controller TouchPadButton and Trigger buttons.
        PointerEventData ped = eventData as PointerEventData;
        if (ped != null)
        {
            if (ped.button != PointerEventData.InputButton.Left)
            {
                return;
            }
        }

        // Move to random new location ±90˚ horzontal.
        Vector3 direction = Quaternion.Euler(
            0,
            Random.Range(-90, 90),
            0) * Vector3.forward;

        // New location on distance
        Vector3 newPos = direction * distance;
        transform.localPosition = newPos;

        gameObject.SetActive(true);
        SetGazedAt(false);
    }







}
