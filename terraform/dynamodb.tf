resource "aws_dynamodb_table" "basic-dynamodb-table" {
  name           = "hackathon-money-game"
  billing_mode   = "PAY_PER_REQUEST"
  hash_key       = "pk"
  range_key      = "sk"
  attribute {
    name = "pk"
    type = "S"
  }

  attribute {
    name = "sk"
    type = "S"
  }
 attribute {
    name = "LongestStreak"
    type = "N"
  }
global_secondary_index {
    name               = "User"
    hash_key           = "sk"
    range_key          = "LongestStreak"
    write_capacity     = 10
    read_capacity      = 10
    projection_type    = "ALL"
  }
  ttl {
    attribute_name = "TimeToExist"
    enabled        = false
  }



  tags = merge(
    local.required_tags
  )
}