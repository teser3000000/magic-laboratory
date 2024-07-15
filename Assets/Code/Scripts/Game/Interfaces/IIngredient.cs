using System.Collections;

public interface IIngredient
{
    object Type { get; }
    IEnumerator ResetOriginalState();
}
