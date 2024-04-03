namespace Bakery.Dtos;

public abstract class Dto
{
    // Select takes a list of fields and sets all other fields to null on the object of the derrived class
    public void Select(string[] fields)
    {
        HashSet<string> nonSelected = new HashSet<string>();
        foreach (var prop in this.GetType().GetProperties())
        {
            nonSelected.Add(prop.Name);
        }
        foreach (var field in fields)
        {
            nonSelected.Remove(field);
        }
        foreach (var prop in nonSelected)
        {
            this.GetType().GetProperty(prop)!.SetValue(this, null);
        }
    }
}
