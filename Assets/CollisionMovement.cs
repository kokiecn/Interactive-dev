using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �U���^�C�v
/// </summary>
internal enum VibrateType
{
    VERTICAL,
    HORIZONTAL
}

/// <summary>
/// �ΏۃI�u�W�F�N�g�̐U�����Ǘ�����N���X
/// </summary>
public class CollisionMovement : MonoBehaviour
{

    [SerializeField] private VibrateType vibrateType;          //�U���^�C�v
    [Range(0, 1)] [SerializeField] private float vibrateRange; //�U����
    [SerializeField] private float vibrateSpeed;               //�U�����x

    private float initPosition;   //�����|�W�V����
    private float newPosition;    //�V�K�|�W�V����
    private float minPosition;    //�|�W�V�����̉���
    private float maxPosition;    //�|�W�V�����̏��
    private bool directionToggle; //�U�������̐؂�ւ��p�g�O��(�I�t�F�l���������Ȃ������ �I���F�l���傫���Ȃ������)
    public bool vibrationFlag;
    // Use this for initialization
    void Start()
    {

        //�����|�W�V�����̐ݒ��U���^�C�v���ɕ�����
        switch (this.vibrateType)
        {
            case VibrateType.VERTICAL:
                this.initPosition = transform.localPosition.y;
                break;
            case VibrateType.HORIZONTAL:
                this.initPosition = transform.localPosition.x;
                break;
        }

        this.newPosition = this.initPosition;
        this.minPosition = this.initPosition - this.vibrateRange;
        this.maxPosition = this.initPosition + this.vibrateRange;
        this.directionToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        //���t���[���U�����s��
        if (vibrationFlag)
        {
            Vibrate();
        }
    }
    public void OnVibration()
    {
        vibrationFlag = !vibrationFlag;
    }

    private void Vibrate()
    {

        //�|�W�V�������U�����͈̔͂𒴂����ꍇ�A�U��������؂�ւ���
        if (this.newPosition <= this.minPosition ||
            this.maxPosition <= this.newPosition)
        {
            this.directionToggle = !this.directionToggle;
        }

        //�V�K�|�W�V������ݒ�
        this.newPosition = this.directionToggle ?
            this.newPosition + (vibrateSpeed * Time.deltaTime) :
            this.newPosition - (vibrateSpeed * Time.deltaTime);
        this.newPosition = Mathf.Clamp(this.newPosition, this.minPosition, this.maxPosition);

        //�V�K�|�W�V��������
        switch (this.vibrateType)
        {
            case VibrateType.VERTICAL:
                this.transform.localPosition = new Vector3(0, this.newPosition, 0);
                break;
            case VibrateType.HORIZONTAL:
                this.transform.localPosition = new Vector3(this.newPosition, 0, 0);
                break;
        }
    }
}