namespace Valve.VR.InteractionSystem
{
    public class LinearDriveExtended : LinearDrive
    {
        public bool resetPositionOnRelease = false;

        protected override void OnDetachedFromHand(Hand hand)
        {
            if (resetPositionOnRelease)
            {
                UpdateLinearMapping(startPosition);
            }

            base.OnDetachedFromHand(hand);
        }
    }
}
