using System.Collections;
using UnityEngine;

public class BoarController : MonoBehaviour
{
    public float percevingRadius;
    [SerializeField]private GameObject player;

    [SerializeField] private float maximumMovingRadius;
    [SerializeField] private Vector3 stageCenter = new Vector3(0,0,0);
    [SerializeField] private float minimumDistanceToPlayer;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float rotationSpeed;

    private bool isRandomWalking = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        var startposition_x = Random.Range(0, maximumMovingRadius - 0.5f);
        var startposition_z = Random.Range(0, maximumMovingRadius - 0.5f);
        transform.position = new Vector3(startposition_x, transform.position.y, startposition_z);
        animator = GetComponent<Animator>();

        StartCoroutine("randomWalk");
        isRandomWalking = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var distanceToPlayer = (transform.position - player.transform.position).magnitude;
        if (percevingRadius > distanceToPlayer)
        {
            //ƒvƒŒƒCƒ„[‚ð‘¨‚¦‚é
            animator.SetBool("isWalking", false);
            StopCoroutine("randomWalk");
            isRandomWalking = false;

            Quaternion rot = Quaternion.LookRotation((player.transform.position - transform.position));//‰ñ“]‚ðŒvŽZ
            rot = Quaternion.Slerp(transform.rotation, rot, rotationSpeed);//‚ä‚Á‚­‚è‰ñ“]‚³‚¹‚é‚æ‚¤‚É’l‚ðŽZo
            transform.rotation = rot;//‰ñ“]
            //—£‚ê‚Ä‚¢‚é‚Ì‚ÅŒü‚©‚Á‚Ä‚­‚éB
            if (distanceToPlayer > minimumDistanceToPlayer)
            {
                animator.SetBool("isWalking", true);
                approachingTo(player.transform.position);//Žw’è‚ÌêŠ‚ÉˆÚ“®
            }
        }else if(distanceToPlayer > percevingRadius)
        {
            //random walk, natural behaviours
            if (!isRandomWalking)
            {
                StartCoroutine("randomWalk");
                isRandomWalking = true;
            }
        }
    }
    private void approachingTo(Vector3 targetPosition)
    {
        transform.Translate(new Vector3(0, 0, walkingSpeed), Space.Self);
        if (maximumMovingRadius < (transform.position - stageCenter).magnitude)
        {
            var amplitude = Vector3.Dot(transform.forward, (transform.position - stageCenter).normalized);
            transform.Translate(-(transform.position - stageCenter).normalized * amplitude * walkingSpeed, Space.World);

        }
    }
    public IEnumerator randomWalk()
    {
        while (true)
        {
            Vector3 destination;
            float distanceFromCenter;
            do
            {
                destination = transform.position + new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
                distanceFromCenter = (destination - stageCenter).magnitude;
            } while (distanceFromCenter > maximumMovingRadius - 0.5f);
            
            
            while (true)
            {
                animator.SetBool("isWalking", true);
                Quaternion rot = Quaternion.LookRotation((destination - transform.position));//‰ñ“]‚ðŒvŽZ
                rot = Quaternion.Slerp(transform.rotation, rot, rotationSpeed);//‚ä‚Á‚­‚è‰ñ“]‚³‚¹‚é‚æ‚¤‚É’l‚ðŽZo
                transform.rotation = rot;//‰ñ“]
                transform.Translate(new Vector3(0, 0, walkingSpeed / 2), Space.Self);
                if ((destination - transform.position).magnitude > 0.5f)
                {
                    yield return new WaitForFixedUpdate();
                }
                else { break; }
            }
            animator.SetBool("isWalking", false);
            yield return new WaitForSeconds(Random.Range(0.5f,3f));
        }
    }
}