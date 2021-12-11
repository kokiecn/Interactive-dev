using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScrollManager : MonoBehaviour
{
    /// <summary>
    /// �X�N���[������1�u���b�N�ƂȂ�v���n�u
    /// </summary>
    [SerializeField]
    protected GameObject scrollBlockObject;

    /// <summary>
    /// �u���b�N�̐����J�n�ʒu
    /// </summary>
    [SerializeField]
    protected Transform blockPopPoint;

    /// <summary>
    /// �u���b�N�̈ړ�����
    /// </summary>
    [SerializeField]
    protected Vector3 blockMoveForward;

    /// <summary>
    /// ���炩���߃u���b�N�𐶐����Ă�����
    /// </summary>
    [SerializeField]
    protected int before_block_create_count = 0;

    /// <summary>
    /// �Ō�̐��������u���b�N��Renderer�R���|�[�l���g(�����p)
    /// </summary>
    private Renderer beforeBlockRenderer;

    void Start()
    {
        // ���������Ɏw�萔���u���b�N�𐶐�����
        if (0 < before_block_create_count)
        {
            // �����Ώۃu���b�N��Bounds
            Bounds blockRendererBounds = scrollBlockObject.GetComponent<Renderer>().bounds;
            blockRendererBounds.center = blockPopPoint.position;

            for (int i = 0; i < before_block_create_count; i++)
            {
                // �ړ��������w�肳��Ă��鎲�݂̂�Bounds.size�����炵���ʒu�ɐ�������
                Vector3 createPosition = blockPopPoint.position + new Vector3(
                    GetBinarizationFloat(blockMoveForward.x) * (blockRendererBounds.size.x * i),
                    GetBinarizationFloat(blockMoveForward.y) * (blockRendererBounds.size.y * i),
                    GetBinarizationFloat(blockMoveForward.z) * (blockRendererBounds.size.z * i)
                );
                CreateBlock(createPosition);
            }
        }
    }

    private void Update()
    {
        // ���̃u���b�N�̐�������p��Bounds�C���X�^���X�쐬
        Bounds beforeBounds = beforeBlockRenderer.bounds;
        beforeBounds.size = beforeBlockRenderer.bounds.size * 2;
        beforeBounds.center += blockMoveForward;

        // �����ʒu���画��p��Bounds������o�Ă��邩����
        if (!beforeBounds.Contains(blockPopPoint.position - new Vector3(0.05f,0,0)))
        {
            CreateBlock(blockPopPoint.position);
        }
    }

    private void CreateBlock(Vector3 createPosition)
    {
        GameObject blockObject = Instantiate(scrollBlockObject, createPosition, scrollBlockObject.transform.rotation,this.transform);

        // �ړ��ƍ폜���s���R���|�[�l���g��ݒ�
        blockObject.AddComponent<AutoDestroy>().time = 5f;
        blockObject.AddComponent<ObjectTransformar>().translate = blockMoveForward;

        beforeBlockRenderer = blockObject.GetComponent<Renderer>();
    }

    private float GetBinarizationFloat(float value)
    {
        if (0 < value)
        {
            return 1;
        }
        else if (value < 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
